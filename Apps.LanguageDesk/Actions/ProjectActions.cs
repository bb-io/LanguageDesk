using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using Apps.LanguageDesk.Restsharp;
using Apps.LanguageDesk.Models.Responses;
using Apps.LanguageDesk.Models.Requests;
using RestSharp;
using Apps.LanguageDesk.Dtos;
using System.Globalization;
using System.Net.Mime;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;

namespace Apps.LanguageDesk.Actions;

[ActionList]
public class ProjectActions : BaseInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public ProjectActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Create project", Description = "Create a new project including files.")]
    public async Task<PostProjectResponse> PostProject([ActionParameter] PostProjectRequest input)
    {
        var file = await _fileManagementClient.DownloadAsync(input.File);

        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest("/api/v1/projects", Method.Post)
            .AddJsonBody(new
            {
                project = new
                {
                    contact_person = input.ContactPerson,
                    content_identifier = input.ContentIdentifier,
                    source_language = input.SourceLang,
                    target_languages = input.TargetLangs,
                    file_transfer_method = "http-push",
                    files = new FileItemDto()
                    {
                        _1 = new FileContent()
                        {
                            Name = input.File.Name,
                            File = Convert.ToBase64String(await file.GetByteData())
                        }
                    },
                    instructions = input.Instructions,
                    company_id = input.CompanyId,
                    deadline = input.Deadline?.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
                }
            });

        if (input.CallbackUrl is not null)
            request.AddQueryParameter("callback_url", input.CallbackUrl);

        var result = client.Execute<BaseProjectResponse<PostProjectResponse>>(request);
        return result.Project;
    }

    [Action("Get project", Description = "Get project by ID")]
    public async Task<ProjectDto> GetProject([ActionParameter] GetProjectRequest input)
    {
        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest($"/api/v1/projects/{input.ProjectId}");
        var result = client.Execute<BaseProjectResponse<ProjectDto>>(request);
        return result.Project;
    }

    [Action("Download delivery files", Description = "Download delivery files from project")]
    public async Task<DownloadDeliveryFilesResponse> DownloadDeliveryFiles([ActionParameter] GetProjectRequest input)
    {
        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/download_delivery_files");
        var fileUrl = await client.ExecuteAsync<BaseProjectResponse<ProjectDeliveryFilesDto>>(request);

        var authToken = InvocationContext.AuthenticationCredentialsProviders.Get("apiKey").Value;
        var downloadFileUrl = fileUrl.Data.Project.DeliveryFilesUrl.SetQueryParameter("auth_token", authToken);

        var fileResponse = await new RestClient().ExecuteAsync(new(downloadFileUrl));
        var file = await _fileManagementClient.UploadAsync(new MemoryStream(fileResponse.RawBytes),
            MediaTypeNames.Application.Zip, $"DeliveryFiles_{input.ProjectId}.zip");
        return new()
        {
            File = file
        };
    }

    [Action("Change project status", Description = "Change project status")]
    public async Task<BaseProjectDto> ChangeProjectStatus([ActionParameter] ChangeProjectStatusRequest input)
    {
        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/change_status", Method.Post)
            .AddJsonBody(new
            {
                project = new
                {
                    status = input.ProjectStatus
                }
            });

        if (input.CallbackUrl is not null)
            request.AddQueryParameter("callback_url", input.CallbackUrl);

        var result = client.Execute<BaseProjectResponse<BaseProjectDto>>(request);
        return result.Project;
    }

    [Action("Download invoice", Description = "Download invoice from project")]
    public async Task<DownloadInvoiceResponse> DownloadInvoice([ActionParameter] GetProjectRequest input)
    {
        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/invoices");
        var fileUrl = client.Execute<BaseProjectResponse<ProjectInvoiceDto>>(request);

        var fileTasks = fileUrl.Project.InvoicesUrls.Select(async url =>
        {
            var fileResponse = await client.ExecuteAsync(new(url.Url));
            return await _fileManagementClient.UploadAsync(new MemoryStream(fileResponse.RawBytes),
                MediaTypeNames.Application.Pdf, $"Invoice_{url.Id}.pdf");
        });

        return new()
        {
            InvoiceFiles = await Task.WhenAll(fileTasks)
        };
    }
}
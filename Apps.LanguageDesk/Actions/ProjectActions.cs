using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.LanguageDesk.Restsharp;
using Apps.LanguageDesk.Models.Responses;
using Apps.LanguageDesk.Models.Requests;
using RestSharp;
using Apps.LanguageDesk.Dtos;
using System.Globalization;
using System.Linq.Expressions;
using File = Blackbird.Applications.Sdk.Common.Files.File;
using System.Net.Mime;

namespace Apps.LanguageDesk.Actions
{
    [ActionList]
    public class ProjectActions : BaseInvocable
    {
        public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Post project", Description = "Post project")]
        public async Task<PostProjectResponse> PostProject([ActionParameter] PostProjectRequest input)
        {
            var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
            var request = new RestRequest("/api/v1/projects", Method.Post);
            request.AddJsonBody(new
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
                            File = Convert.ToBase64String(input.File.Bytes)
                        }
                    },
                    instructions = input.Instructions,
                    company_id = input.CompanyId,
                    deadline = input.Deadline != null ? ((DateTime)input.Deadline).ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture) : null
                }
            });
            var result = client.Execute<BaseProjectResponse<PostProjectResponse>>(request);
            return result.Project;
        }

        [Action("Get project", Description = "Get project by Id")]
        public async Task<ProjectDto> GetProject([ActionParameter] GetProjectRequest input)
        {
            var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
            var request = new RestRequest($"/api/v1/projects/{input.ProjectId}", Method.Get);  
            var result = client.Execute<BaseProjectResponse<ProjectDto>>(request);
            return result.Project;
        }

        [Action("Download delivery files", Description = "Download delivery files from project")]
        public async Task<DownloadDeliveryFilesResponse> DownloadDeliveryFiles([ActionParameter] GetProjectRequest input)
        {
            var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
            var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/download_delivery_files", Method.Get);
            var fileUrl = client.Execute<BaseProjectResponse<ProjectDeliveryFilesDto>>(request);
            var restClient = new RestClient();
            var fileRequest = new RestRequest(fileUrl.Project.DeliveryFilesUrl, Method.Get);
            var fileResult = restClient.Get(fileRequest);
            return new DownloadDeliveryFilesResponse() { 
                File = new File(fileResult.RawBytes) 
                { 
                    Name = $"DeliveryFiles_{input.ProjectId}.zip",
                    ContentType = fileResult.ContentType ?? MediaTypeNames.Application.Zip
                } 
            };
        }

        [Action("Change project status", Description = "Change project status")]
        public async Task<BaseProjectDto> ChangeProjectStatus([ActionParameter] ChangeProjectStatusRequest input)
        {
            var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
            var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/change_status", Method.Post);
            request.AddJsonBody(new
            {
                project = new
                {
                    status = input.ProjectStatus
                }
            });
            var result = client.Execute<BaseProjectResponse<BaseProjectDto>>(request);
            return result.Project;
        }

        [Action("Download invoice", Description = "Download invoice from project")]
        public async Task<DownloadInvoiceResponse> DownloadInvoice([ActionParameter] GetProjectRequest input)
        {
            var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
            var request = new RestRequest($"/api/v1/projects/{input.ProjectId}/invoices", Method.Get);
            var fileUrl = client.Execute<BaseProjectResponse<ProjectInvoiceDto>>(request);
            var result = new DownloadInvoiceResponse() { InvoiceFiles = new List<File>()};
            foreach (var url in fileUrl.Project.InvoicesUrls)
            {
                var restClient = new RestClient();
                var fileRequest = new RestRequest(url.Url, Method.Get);
                result.InvoiceFiles.Add(
                    new File(restClient.Execute(fileRequest).RawBytes)
                    {
                        Name = $"Invoice_{url.Id}.pdf",
                        ContentType = MediaTypeNames.Application.Pdf
                    }
                );
            }
            return result;
        }
    }
}

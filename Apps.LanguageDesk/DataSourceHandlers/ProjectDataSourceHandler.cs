using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Apps.LanguageDesk.Models.Responses;
using Apps.LanguageDesk.Restsharp;
using RestSharp;

namespace Apps.LanguageDesk.DataSourceHandlers;

public class ProjectDataSourceHandler : BaseInvocable, IDataSourceHandler
{
    public ProjectDataSourceHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Dictionary<string, string> GetData(DataSourceContext context)
    {
        var client = new LanguageDeskClient(InvocationContext.AuthenticationCredentialsProviders);
        var request = new RestRequest($"/api/v1/projects");
        var result = client.Execute<List<PostProjectResponse>>(request);
        return result
            .Where(e => context.SearchString == null || e.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(e => e.Id, e => e.Name);
    }
}
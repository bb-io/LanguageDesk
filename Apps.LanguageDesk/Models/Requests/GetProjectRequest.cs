using Apps.LanguageDesk.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.LanguageDesk.Models.Requests;

public class GetProjectRequest
{
    [Display("Project")]
    [DataSource(typeof(ProjectDataSourceHandler))]
    public string ProjectId { get; set; }
}
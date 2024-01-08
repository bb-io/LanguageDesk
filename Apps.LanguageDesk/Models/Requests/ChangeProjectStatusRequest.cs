using Apps.LanguageDesk.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.LanguageDesk.Models.Requests;

public class ChangeProjectStatusRequest : GetProjectRequest
{
    [Display("Project status")]
    [DataSource(typeof(ProjectStatusDataHandler))]
    public string ProjectStatus { get; set; }
    
    [Display("Callback URL")]
    public string? CallbackUrl { get; set; }
}
using Blackbird.Applications.Sdk.Common;

namespace Apps.LanguageDesk.Webhooks.Payloads;

public class ProjectPayload
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    public string Status { get; set; }
}
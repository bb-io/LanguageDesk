using Newtonsoft.Json;

namespace Apps.LanguageDesk.Webhooks.Payloads;

public class ProjectPayload
{
    [JsonProperty("project[id]")]
    public string ProjectId { get; set; }
    
    [JsonProperty("project[status]")]
    public string Status { get; set; }
}
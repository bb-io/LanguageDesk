using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.LanguageDesk.Dtos;

public class ProjectDto : BaseProjectDto
{
    [JsonProperty("delivery_date")]
    [Display("Delivery date")]
    public string DeliveryDate { get; set; }

    [JsonProperty("company_id")]
    [Display("Company ID")]
    public string CompanyId { get; set; }
}

public class BaseProjectDto
{
    [Display("Project ID")]
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
}
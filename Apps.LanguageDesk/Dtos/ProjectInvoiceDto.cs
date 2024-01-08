using Newtonsoft.Json;

namespace Apps.LanguageDesk.Dtos;

public class ProjectInvoiceDto
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("company_id")]
    public string CompanyId { get; set; }

    [JsonProperty("invoices_urls")]
    public List<InvoiceUrl> InvoicesUrls { get; set; }
}

public class InvoiceUrl
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
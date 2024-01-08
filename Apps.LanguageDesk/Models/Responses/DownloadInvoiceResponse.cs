using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.LanguageDesk.Models.Responses;

public class DownloadInvoiceResponse
{
    [Display("Invoice files")]
    public IEnumerable<FileReference> InvoiceFiles { get; set; }
}
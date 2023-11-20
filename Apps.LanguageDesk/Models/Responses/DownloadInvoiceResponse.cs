using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.LanguageDesk.Models.Responses
{
    public class DownloadInvoiceResponse
    {
        [Display("Invoice files")]
        public List<File> InvoiceFiles { get; set; }
    }
}

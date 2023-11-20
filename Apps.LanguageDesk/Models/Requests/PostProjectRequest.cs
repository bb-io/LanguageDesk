using Apps.LanguageDesk.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.LanguageDesk.Models.Requests
{
    public class PostProjectRequest
    {
        [Display("Contact person")]
        [JsonProperty("contact_person")]
        public string ContactPerson { get; set; }

        [JsonProperty("source_language")]
        [Display("Source language")]
        [DataSource(typeof(SourceLanguageDataHandler))]
        public string SourceLang { get; set; }

        [JsonProperty("target_language")]
        [Display("Target languages")]
        [DataSource(typeof(TargetLanguageDataHandler))]
        public List<string> TargetLangs { get; set; }

        [JsonProperty("content_identifier")]
        [Display("Content identifier")]
        public string ContentIdentifier { get; set; }

        [JsonProperty("content_identifier")]
        [Display("File")]
        public File File { get; set; }

        [Display("Remove files afterwards")]
        public bool Remove { get; set; }

        [JsonProperty("company_id")]
        [Display("Company ID")]
        public string? CompanyId { get; set; }

        [JsonProperty("instructions")]
        [Display("Instructions")]
        public string? Instructions { get; set; }

        [JsonProperty("deadline")]
        [Display("Deadline")]
        public DateTime? Deadline { get; set; }
    }
}

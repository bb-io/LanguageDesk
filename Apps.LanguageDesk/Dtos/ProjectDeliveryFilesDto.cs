using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.LanguageDesk.Dtos
{
    public class ProjectDeliveryFilesDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("delivery_files_url")]
        public string DeliveryFilesUrl { get; set; }
    }
}

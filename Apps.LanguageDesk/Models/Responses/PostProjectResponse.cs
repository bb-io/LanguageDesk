using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.LanguageDesk.Models.Responses
{
    public class PostProjectResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("company_id")]
        [Display("Company ID")]
        public string CompanyId { get; set; }

        [JsonProperty("created_at")]
        [Display("Created at")]
        public string CreatedAt { get; set; }
    }

    public class BaseProjectResponse<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("project")]
        public T Project { get; set; }
    }
}

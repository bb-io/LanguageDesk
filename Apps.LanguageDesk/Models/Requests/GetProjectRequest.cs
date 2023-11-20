using Apps.LanguageDesk.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.LanguageDesk.Models.Requests
{
    public class GetProjectRequest
    {
        [Display("Project")]
        [DataSource(typeof(ProjectDataSourceHandler))]
        public string ProjectId { get; set; }
    }
}

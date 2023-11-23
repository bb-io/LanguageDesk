using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.LanguageDesk.DataSourceHandlers
{
    public class ProjectStatusDataHandler : EnumDataHandler
    {
        protected override Dictionary<string, string> EnumValues => new()
        {
            {"draft", "Draft"},
            {"potential", "Potential"},
            {"cancel", "Cancel"},
            {"decline", "Decline"},
            {"approve_quote", "In Progress (approved)"},
        };
    }
}

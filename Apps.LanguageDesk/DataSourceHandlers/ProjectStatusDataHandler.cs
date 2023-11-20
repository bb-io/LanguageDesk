using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.LanguageDesk.DataSourceHandlers
{
    public class ProjectStatusDataHandler : BaseInvocable, IDataSourceHandler
    {
        public ProjectStatusDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            var statuses = new Dictionary<string, string>
            {
                {"draft", "Draft"},
                {"potential", "Potential"},
                {"cancel", "Cancel"},
                {"decline", "Decline"},
                {"approve_quote", "In Progress (approved)"},
            };
            return statuses
                .Where(s => context.SearchString == null || s.Value.Contains(context.SearchString))
                .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}

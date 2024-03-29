﻿using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.LanguageDesk.DataSourceHandlers;

public class ProjectStatusDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        {"draft", "Draft"},
        {"potential", "Potential"},
        {"cancel", "Cancelled"},
        {"decline", "Declined"},
        {"approve_quote", "In Progress (approved)"},
    };
}
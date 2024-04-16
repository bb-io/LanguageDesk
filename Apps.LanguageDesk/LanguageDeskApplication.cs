using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.LanguageDesk;

public class LanguageDeskApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.LspPortal];
        set { }
    }
    
    public string Name
    {
        get => "LanguageDesk";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}
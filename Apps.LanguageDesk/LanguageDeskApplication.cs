using Blackbird.Applications.Sdk.Common;

namespace Apps.LanguageDesk;

public class LanguageDeskApplication : IApplication
{
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
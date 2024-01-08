using Blackbird.Applications.Sdk.Common.Authentication;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Apps.LanguageDesk.Restsharp;

public class LanguageDeskClient : RestClient
{
    public LanguageDeskClient(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) :
        base(new RestClientOptions() { ThrowOnAnyError = true, BaseUrl = new Uri(authenticationCredentialsProviders.First(c => c.KeyName == "url").Value) }, configureSerialization: s => s.UseNewtonsoftJson()) 
    {
        this.AddDefaultQueryParameter("auth_token", authenticationCredentialsProviders.First(c => c.KeyName == "apiKey").Value);
    }

    public T Get<T>(RestRequest request)
    {
        var resultStr = this.Get(request).Content;
        return JsonConvert.DeserializeObject<T>(resultStr, new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        })!;
    }

    public T Execute<T>(RestRequest request)
    {
        var resultStr = this.Execute(request).Content;
        return JsonConvert.DeserializeObject<T>(resultStr, new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore
        })!;
    }
}
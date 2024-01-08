using System.Web;
using Apps.LanguageDesk.Webhooks.Payloads;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.LanguageDesk.Webhooks;

[WebhookList]
public class WebhookList
{
    [Webhook("On project status changed", Description = "On specific project's status changed")]
    public Task<WebhookResponse<ProjectPayload>> OnProjectStatusChanged(WebhookRequest webhookRequest)
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);
        
        var values = HttpUtility.ParseQueryString(payload);
        return Task.FromResult<WebhookResponse<ProjectPayload>>(new()
        {
            Result = new()
            {
                ProjectId = values["project[id]"]!,
                Status = values["project[status]"]!
            }
        });
    }
}
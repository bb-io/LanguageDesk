using Apps.LanguageDesk.Webhooks.Payloads;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.LanguageDesk.Webhooks;

[WebhookList]
public class WebhookList
{
    [Webhook("On project status changed", Description = "On specific project's status changed")]
    public Task<WebhookResponse<CallbackProjectResponse>> OnProjectStatusChanged(WebhookRequest webhookRequest)
    {
        var payload = webhookRequest.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);
        
        var data = JsonConvert.DeserializeObject<ProjectPayload>(payload)!;
        return Task.FromResult<WebhookResponse<CallbackProjectResponse>>(new()
        {
            Result = new()
            {
                ProjectId = data.ProjectId,
                Status = data.Status
            }
        });
    }
}
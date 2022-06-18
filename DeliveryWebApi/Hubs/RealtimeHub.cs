using Microsoft.AspNetCore.SignalR;

namespace DeliveryWebApi.Hubs;

public class RealtimeHub : Hub
{
    public async Task SendNotification()
    {
        var message = Contents.ExistedObject + "SignalR notification " + DateTime.Now.ToString();
        await Clients.All.SendAsync(message);
    }

    // Test 
    public async Task<string> GetListTags()
    {
        var message = Contents.ExistedObject + "SignalR message " + DateTime.Now.ToString();
        await Clients.All.SendAsync(message);
        return message;
    }
}

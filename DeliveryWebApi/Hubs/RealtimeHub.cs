using Microsoft.AspNetCore.SignalR;

namespace DeliveryWebApi.Hubs;

public class RealtimeHub : Hub
{
    public async Task SendNotification(Message message)
    {
        await Clients.All.SendAsync(message.Content);
    }

    //public async Task SendTrackingMonitor()
    //{
    //    await Clients.All.SendAsync("");
    //}
}

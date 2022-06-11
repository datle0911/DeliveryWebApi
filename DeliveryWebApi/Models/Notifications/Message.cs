namespace DeliveryWebApi.Models.Notifications;

public class Message
{
    public Message(string content)
    {
        Content = content;
    }

    public string Content { get; set; }
}

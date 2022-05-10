namespace DeliveryWebApi.Models;

public class User
{
#pragma warning disable CS8618
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public ERoles Roles { get; set; }
#pragma warning restore CS8618
}

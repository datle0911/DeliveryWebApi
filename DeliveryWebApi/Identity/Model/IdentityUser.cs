namespace DeliveryWebApi.Identity.Model;

public class IdentityUser
{
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}

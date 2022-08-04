namespace DeliveryWebApi.Identity.ViewModels;

public class IdentityCustomerVm
{
    public IdentityCustomerVm(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}

namespace DeliveryWebApi.Identity.ViewModel;

public class IdentityUserVm
{
    public IdentityUserVm(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}

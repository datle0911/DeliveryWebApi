namespace DeliveryWebApi.Identity.ViewModels;

public class IdentityUserVm
{
    public IdentityUserVm(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
}

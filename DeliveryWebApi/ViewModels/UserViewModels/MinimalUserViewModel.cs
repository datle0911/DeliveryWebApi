namespace DeliveryWebApi.ViewModels.UserViewModels;

public class MinimalUserViewModel
{
    public MinimalUserViewModel(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
}

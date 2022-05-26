namespace DeliveryWebApi.ViewModels.UserViewModels;

public class UserViewModel
{
    public UserViewModel()
    {

    }
    public UserViewModel(string userName, string password, string fullName, string phoneNumber, ERoles roles)
    {
        UserName = userName;
        Password = password;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Roles = roles;
    }

    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public ERoles Roles { get; set; }
}

namespace DeliveryWebApi.Models;

public class User
{
    public User()
    {

    }
    public User(string userName, string password, string fullName, string phoneNumber, ERoles roles)
    {
        UserName = userName;
        Password = password;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Roles = roles;
    }

    public User(int userId, string userName, string password, string fullName, string phoneNumber, ERoles roles)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Roles = roles;
    }
#pragma warning disable CS8618
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public ERoles Roles { get; set; }
#pragma warning restore CS8618
}

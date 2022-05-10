namespace DeliveryWebApi.ViewModels;

public class CustomerViewModel
{
    public CustomerViewModel()
    {

    }
    public CustomerViewModel(string customerUserName, string customerPassword, string customerFullName, string customerPhoneNumber, string customerEmail)
    {
        CustomerUserName = customerUserName;
        CustomerPassword = customerPassword;
        CustomerFullName = customerFullName;
        CustomerPhoneNumber = customerPhoneNumber;
        CustomerEmail = customerEmail;
    }

    public string CustomerUserName { get; set; }
    public string CustomerPassword { get; set; }
    public string CustomerFullName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerEmail { get; set; }
}

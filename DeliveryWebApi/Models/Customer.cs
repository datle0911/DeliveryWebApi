namespace DeliveryWebApi.Models;

public class Customer
{
    public Customer(int customerId, string customerUserName, string customerPassword, string customerFullName, string customerPhoneNumber, string customerEmail)
    {
        CustomerId = customerId;
        CustomerUserName = customerUserName;
        CustomerPassword = customerPassword;
        CustomerFullName = customerFullName;
        CustomerPhoneNumber = customerPhoneNumber;
        CustomerEmail = customerEmail;
    }
    public Customer()
    {

    }
#pragma warning disable CS8618
    public int CustomerId { get; set; }
    public string CustomerUserName { get; set; }
    public string CustomerPassword { get; set; }
    public string CustomerFullName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerEmail { get; set; }
#pragma warning restore CS8618
}

namespace DeliveryWebApi.Identity.ViewModels;

public class CustomerLoginResultVm
{
    public CustomerLoginResultVm(TokenVm token, IdentityCustomerVm identity)
    {
        Token = token;
        Identity = identity;
    }

    public TokenVm Token { get; set; }
    public IdentityCustomerVm Identity { get; set; }
}

namespace DeliveryWebApi.Identity.ViewModel;

public class LoginResultVm
{
    public LoginResultVm(TokenVm token, IdentityUserVm identity)
    {
        Token = token;
        Identity = identity;
    }

    public TokenVm Token { get; set; }
    public IdentityUserVm Identity { get; set; }
}

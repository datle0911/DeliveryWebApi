namespace DeliveryWebApi.Identity.ViewModels;

public class UserLoginResult
{
    public UserLoginResult(TokenVm token, IdentityUserVm identity)
    {
        Token = token;
        Identity = identity;
    }

    public TokenVm Token { get; set; }
    public IdentityUserVm Identity { get; set; }
}

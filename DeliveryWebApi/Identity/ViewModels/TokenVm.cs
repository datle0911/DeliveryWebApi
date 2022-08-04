namespace DeliveryWebApi.Identity.ViewModels;

public class TokenVm
{
    public TokenVm(string authToken, DateTime validTo)
    {
        AuthToken = authToken;
        ValidTo = validTo;
    }

    public string AuthToken { get; set; }
    public DateTime ValidTo { get; set; }
}

namespace DeliveryWebApi.Identity.Helpers;

public interface IIdentityHelper
{
    public Tuple<byte[], byte[]> CreatePasswordHash(string password);
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    public TokenVm CreateToken(string userNameOrEmail, string role);
}

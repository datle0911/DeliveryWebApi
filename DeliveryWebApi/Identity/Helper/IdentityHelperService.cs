using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DeliveryWebApi.Identity.Helper;

public class IdentityHelperService : IIdentityHelper
{
    private readonly IConfiguration _config;

    public IdentityHelperService(IConfiguration config)
    {
        _config = config;
    }

    public Tuple<byte[], byte[]> CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        var passwordSalt = hmac.Key;
        var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Tuple.Create(passwordHash, passwordSalt);
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }

    public TokenVm CreateToken(IdentityUserVm identityUserVm)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, identityUserVm.Email)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _config.GetSection("Tokens:VietNam").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: cred);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        var result = new TokenVm(jwt, token.ValidTo);

        return result;
    }
}

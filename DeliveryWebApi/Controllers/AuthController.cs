namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IIdentityHelper _identityHelperService;

    public AuthController(ICustomerService customerService, IIdentityHelper identityHelperService)
    {
        _customerService = customerService;
        _identityHelperService = identityHelperService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(IdentityUserVm userVm)
    {
        var customer = await _customerService.FindByEmailAsync(userVm.Email);
        if (customer is null)
        {
            return BadRequest("Customer not found");
        }

        var hasing = _identityHelperService.CreatePasswordHash(customer.CustomerPassword);

        if(!_identityHelperService.VerifyPasswordHash(userVm.Password, hasing.Item1, hasing.Item2))
        {
            return BadRequest("Wrong password");
        }

        var token = _identityHelperService.CreateToken(userVm);
        var result = new LoginResultVm(token, userVm);

        return Ok(result);
    }
}

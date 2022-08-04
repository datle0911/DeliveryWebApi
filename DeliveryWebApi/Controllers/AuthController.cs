namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IUserService _userService;
    private readonly IIdentityHelper _identityHelperService;

    public AuthController(ICustomerService customerService, IUserService userService, IIdentityHelper identityHelperService)
    {
        _customerService = customerService;
        _userService = userService;
        _identityHelperService = identityHelperService;
    }

    [HttpPost("login/customer")]
    public async Task<IActionResult> Login(IdentityCustomerVm customerVm)
    {
        // Find existed customer
        var customer = await _customerService.FindByEmailAsync(customerVm.Email);
        if (customer is null)
        {
            return BadRequest("Customer not found");
        }

        var hasing = _identityHelperService.CreatePasswordHash(customer.CustomerPassword);

        // Verify if password is correct
        if(!_identityHelperService.VerifyPasswordHash(customerVm.Password, hasing.Item1, hasing.Item2))
        {
            return BadRequest("Wrong password");
        }

        var token = _identityHelperService.CreateToken(customerVm.Email);
        var result = new CustomerLoginResultVm(token, customerVm);

        return Ok(result);
    }

    [HttpPost("login/user")]
    public async Task<IActionResult> LoginForAdmin(IdentityUserVm userVm)
    {
        var user = await _userService.GetByUserNameAsync(userVm.UserName);
        if (user is null)
        {
            return BadRequest("Customer not found");
        }

        var hasing = _identityHelperService.CreatePasswordHash(user.Password);

        if (!_identityHelperService.VerifyPasswordHash(userVm.Password, hasing.Item1, hasing.Item2))
        {
            return BadRequest("Wrong password");
        }

        var token = _identityHelperService.CreateToken(userVm.UserName);
        var result = new UserLoginResult(token, userVm);

        return Ok(result);
    }
}

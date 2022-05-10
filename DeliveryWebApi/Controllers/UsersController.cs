namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly UserService _userService;
    public UsersController(UserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync(User user)
    {
        await _userService.AddAsync(user);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(User user)
    {
        await _userService.UpdateAsync(user);

        return Ok();
    }

    [HttpGet("{name}")]
    public async Task<IEnumerable<User>> GetByName(string name)
    {
        var users = await _userService.GetByName(name);

        return users;
    }
}

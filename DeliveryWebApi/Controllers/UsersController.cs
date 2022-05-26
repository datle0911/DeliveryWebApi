namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    public UsersController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserViewModel user)
    {
        var mockUser = _userService.GetByUserName(user.UserName);
        if (mockUser.Result is not null)
        {
            return BadRequest("UserName existed");
        }

        var resource = _mapper.Map<UserViewModel, User>(user);
        await _userService.AddAsync(resource);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(UserViewModel user)
    {
        var resource = _mapper.Map<UserViewModel, User>(user);
        await _userService.UpdateAsync(resource);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(MinimalUserViewModel user)
    {
        var resource = _userService.FindByMinimal(user);
        if(resource.Result is null)
        {
            return BadRequest("User not existed");
        }

        await _userService.DeleteAsync(resource.Result);

        return Ok();
    }

    [HttpGet("{name}")]
    public async Task<IEnumerable<UserViewModel>> GetByName(string name)
    {
        var users = await _userService.GetByName(name);

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
    }
}

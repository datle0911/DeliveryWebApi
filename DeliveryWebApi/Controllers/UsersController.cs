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

    [HttpGet("{name}")]
    public async Task<IEnumerable<UserViewModel>> GetByName(string name)
    {
        var users = await _userService.GetByName(name);

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
    }
}

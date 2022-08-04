namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IHubContext<RealtimeHub> _realtimeHub;
    public UsersController(IUserService userService, IMapper mapper, IHubContext<RealtimeHub> realtimeHub)
    {
        _userService = userService;
        _mapper = mapper;
        _realtimeHub = realtimeHub;
    }

    [HttpPost]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> PostAsync(UserViewModel user)
    {
        // Check if existed with UserName
        var mockUser = _userService.GetByUserNameAsync(user.UserName);
        if (mockUser.Result is not null)
        {
            var warning = new Message(Contents.ExistedObject + "User " + user.UserName);
            return BadRequest(warning.Content);
        }

        // Save to database
        var resource = _mapper.Map<UserViewModel, User>(user);
        await _userService.AddAsync(resource);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPost + "User " + user.UserName + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<User> patchEntity)
    {
        // Update
        await _userService.UpdateAsync(id, patchEntity);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPutPatch + "User with ID: " + id.ToString() + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpDelete]
    [Authorize(Roles = "admin,user")]
    public async Task<IActionResult> DeleteAsync(MinimalUserViewModel user)
    {
        // Check if not existed
        var resource = _userService.FindByMinimal(user);
        if(resource.Result is null)
        {
            var warning = new Message(Contents.ExistedObject + "UserName: " + user.UserName);
            return BadRequest(warning.Content);
        }

        // Delete User
        await _userService.DeleteAsync(resource.Result);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyDelete + "User " + user.UserName + ". Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    public async Task<IEnumerable<UserViewModel>> GetListAsync()
    {
        var users = await _userService.GetListAsync();

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
    }

    [HttpGet("{name}")]
    [Authorize(Roles = "user,admin")]
    public async Task<IEnumerable<UserViewModel>> GetByNameAsync(string name)
    {
        var users = await _userService.GetByNameAsync(name);

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
    }
}

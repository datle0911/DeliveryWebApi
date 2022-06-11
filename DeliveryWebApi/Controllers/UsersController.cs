namespace DeliveryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : Controller
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    private readonly IHubContext<RealtimeHub> _realtimeHub;
    public UsersController(UserService userService, IMapper mapper, IHubContext<RealtimeHub> realtimeHub)
    {
        _userService = userService;
        _mapper = mapper;
        _realtimeHub = realtimeHub;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(UserViewModel user)
    {
        // Check if existed with UserName
        var mockUser = _userService.GetByUserName(user.UserName);
        if (mockUser.Result is not null)
        {
            // Realtime signalR transmit
            var warning = new Message(Contents.ExistedObject + "User");
            await _realtimeHub.Clients.All.SendAsync(warning.Content);

            return BadRequest(warning.Content);
        }

        // Save to database
        var resource = _mapper.Map<UserViewModel, User>(user);
        await _userService.AddAsync(resource);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPost + "User. Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<User> patchEntity)
    {
        // Update
        await _userService.UpdateAsync(id, patchEntity);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyPutPatch + "User. Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(MinimalUserViewModel user)
    {
        // Check if not existed
        var resource = _userService.FindByMinimal(user);
        if(resource.Result is null)
        {
            var warning = new Message(Contents.ExistedObject + "User");
            return BadRequest(warning.Content);
        }

        // Delete User
        await _userService.DeleteAsync(resource.Result);

        // Realtime signalR transmit
        var message = new Message(Contents.SuccessfullyDelete + "User. Timestamp: " + DateTime.Now.ToString());
        await _realtimeHub.Clients.All.SendAsync(message.Content);

        // Complete
        return Ok(message.Content);
    }

    [HttpGet("{name}")]
    public async Task<IEnumerable<UserViewModel>> GetByName(string name)
    {
        var users = await _userService.GetByName(name);

        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
    }
}

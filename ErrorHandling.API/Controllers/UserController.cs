using ErrorHandling.API.Converters;
using ErrorHandling.Service.Services;
using Microsoft.AspNetCore.Mvc;
using ErrorHandling.API.Models;
using ErrorHandling.Service.Model;
using ErrorHandling.API.Filters;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("user")]
[ValidationFilter]
[TypeFilter(typeof(GlobalExceptionFilter))]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return users.ToDto().ToList();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Post(UserAddDto user)
    {
        UserModel model = await _userService.AddAsync(user.ToModel());
        return model.ToDto();
    }
}
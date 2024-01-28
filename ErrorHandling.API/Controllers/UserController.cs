using ErrorHandling.API.Model;
using ErrorHandling.API.Converters;
using ErrorHandling.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("user")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<CompanyDto>> GetAll()
    {
        var users = _userService.GetAll();
        return users.ToDto().ToList();
    }
}
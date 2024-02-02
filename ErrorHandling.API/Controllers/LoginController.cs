using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("login")]
[AllowAnonymous]
public class LoginController : Controller
{
    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {

        return null;
    }
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return null;
    }
}

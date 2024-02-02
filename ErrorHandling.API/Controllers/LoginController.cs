using ErrorHandling.Service.Model;
using ErrorHandling.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ErrorHandling.API.Controllers;

[ApiController]
[Route("login")]
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public LoginController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        UserModel user = await _userService.Login(dto.Username, dto.Password);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
        };
        var sectoken = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now,
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(sectoken);
        return Ok(new { token = token });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return null;
    }
}
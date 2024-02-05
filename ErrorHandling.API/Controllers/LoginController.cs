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
    private readonly JwtOptions _jwtOptions;
    private readonly IUserService _userService;

    public LoginController(JwtOptions  jwtOptions, IUserService userService)
    {
        _jwtOptions = jwtOptions;
        _userService = userService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        UserModel user = await _userService.Login(dto.Username, dto.Password);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("companyId", user.CompanyId.ToString()),
            new Claim("role", user.IsAdmin.ToString())
        };
        var sectoken = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(sectoken);
        return Ok(new { token = token });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok(new {token=""});
    }
}
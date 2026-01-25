using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{

  private readonly SignInManager<AppUser> _signInManager;
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
  {
    _signInManager = signInManager;
    _tokenService = tokenService;
    _userManager = userManager;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterDto user)
  {
    try
    {
      var appUser = new AppUser
      {
        Email = user.Email,
        UserName = user.Email
      };
      var createUser = await _userManager.CreateAsync(appUser, user.PasswordHash!);
      if (!createUser.Succeeded) return StatusCode(500, createUser.Errors);
      var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
      if (!roleResult.Succeeded) return StatusCode(500, roleResult.Errors);
      var accessToken = _tokenService.CreateToken(appUser);
      var refreshToken = _tokenService.GenerateRefreshToken();
      appUser.RefreshToken = refreshToken;
      appUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
      await _userManager.UpdateAsync(appUser);
      return Ok(
        new NewUserDto
        {
          Email = appUser.Email,
          Token = accessToken,
          RefreshToken = refreshToken
        }
      );
    }
    catch (Exception e)
    {
      return StatusCode(500, e);
    }
  }
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
  {
    try
    {
      var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.Email);
      if (user == null) return Unauthorized("Invalid credentials");
      var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password!, false);
      if (!result.Succeeded) return Unauthorized("Username or Password is correct");

      var accessToken = _tokenService.CreateToken(user);
      var refreshToken = _tokenService.GenerateRefreshToken();

      //save refresh token to db
      user.RefreshToken = refreshToken;
      user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
      await _userManager.UpdateAsync(user);

      return Ok(
        new NewUserDto
        {
          Email = user.Email,
          RefreshToken = user.RefreshToken,
          Token = _tokenService.CreateToken(user)
        }
      );
    }
    catch (Exception e)
    {
      return StatusCode(500, e);
    }
    ;
  }
  [HttpPost("logout")]
  [Authorize]
  public async Task<IActionResult> Logout()
  {
    //From claims
    var email = User.FindFirstValue(ClaimTypes.Email);
    var user = await _userManager.FindByEmailAsync(email!);
    if (user == null) return Unauthorized();
    user.RefreshToken = null;
    user.RefreshTokenExpiryTime = null;
    await _userManager.UpdateAsync(user);
    return Ok("user logged out.");
  }

  [HttpPost("refresh")]
  public async Task<IActionResult> Refresh([FromBody] TokenRequestDto tokenRequest)
  {
    if (tokenRequest == null) return BadRequest("Invalid Client Request");
    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == tokenRequest.RefreshToken);
    if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow) return Unauthorized("Invalid or expired refresh token");

    //New tokens
    var newAccesstoken = _tokenService.CreateToken(user);
    var newRefreshToken = _tokenService.GenerateRefreshToken();

    user.RefreshToken = newRefreshToken;
    user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
    await _userManager.UpdateAsync(user);
    return Ok(
      new NewUserDto
      {
        Email = user.Email,
        Token = newAccesstoken,
        RefreshToken = newRefreshToken
      }
    );
  }
}
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public DateTime? CreatedAt { get; set; } = DateTime.Now;

  //Token Refresh
  public string? RefreshToken { get; set; }
  public DateTime? RefreshTokenExpiryTime { get; set; }
}
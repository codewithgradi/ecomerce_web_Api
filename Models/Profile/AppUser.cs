using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
}
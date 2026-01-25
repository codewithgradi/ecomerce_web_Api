public class UserDto
{
  public string? Id { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? PhoneNumber { get; set; }
  public string? Email { get; set; }
  public string? PasswordHash { get; set; }
  public DateTime? CreatedAt { get; set; } = DateTime.Now;

  public string Token { get; set; } = string.Empty;
  public string RefreshToken { get; set; } = string.Empty;
}
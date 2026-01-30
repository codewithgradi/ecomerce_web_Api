public class Cart
{
  public int Id { get; set; }
  public string? UserId { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; }

  public AppUser? AppUser { get; set; }
}
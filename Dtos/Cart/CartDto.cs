public class CartDto
{
  public int Id { get; set; }
  public string? UserId { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; }
  public List<CartItemDto> CartItems { get; set; }
  = new List<CartItemDto>();
  public AppUser? AppUser { get; set; }
}
public class Product
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  public string? Brand { get; set; }
  public bool IsActive { get; set; } = true;

  public Category? Category { get; set; }
}
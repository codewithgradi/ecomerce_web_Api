public class Product
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  public string? Brand { get; set; }
  public bool IsInstock { get; set; }

  public Category? Category { get; set; }

  public ICollection<Variants> Variants { get; set; } = new List<Variants>();
}
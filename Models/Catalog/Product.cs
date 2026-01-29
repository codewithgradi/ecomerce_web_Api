public class Product
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  public string? Brand { get; set; }
  public bool IsInstock { get; set; }

  public Category? Category { get; set; }

  public ICollection<Variant> Variants { get; set; }
   = new List<Variant>();

  public ICollection<Review> Reviews { get; set; } = new List<Review> { };
}
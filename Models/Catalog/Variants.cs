public class Variants
{
  public int Id { get; set; }
  public int ProductId { get; set; }
  public string? Sku { get; set; }
  public string? Color { get; set; }
  public int Size { get; set; }
  public double Decimal { get; set; }
  public int StockQuantity { get; set; }

  public Product? Product { get; set; }
}
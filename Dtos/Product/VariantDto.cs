public class VariantDto
{
  public int Id { get; set; }
  public string? Sku { get; set; }
  public string? Color { get; set; }
  public int Size { get; set; }
  public bool InStock { get; set; }

  public decimal Price { get; set; }
  public int StockQuantity { get; set; }
}
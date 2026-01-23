public class ProductResponse
{
  public int Id { get; set; }
  public string? Brand { get; set; }

  //Category Data (Flattened)
  public string? CategoryName { get; set; }
  public string? CategorySlug { get; set; }
  //
  public bool IsInstock => Variants.Any(v => v.StockQuantity > 0);
  public decimal Price => Variants.Any() ? Variants.Min(v => v.Price) : 0;

  //nested variants
  public List<VariantDto> Variants { get; set; } = new();

}
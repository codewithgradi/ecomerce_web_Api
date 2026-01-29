public class CreateProductDto
{
  public int Id { get; set; }
  public int CategoryId { get; set; }
  public string? Brand { get; set; }
  public List<VariantCreateDto> Variants { get; set; } = new List<VariantCreateDto> { };
}
public class VariantCreateDto
{
  public string? Sku { get; set; }
  public string? Color { get; set; }
  public int Size { get; set; }
  public bool InStock { get; set; }

  public decimal Price { get; set; }
  public int StockQuantity { get; set; }
}
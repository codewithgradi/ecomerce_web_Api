public class CartItemDto
{
  public int Id { get; set; }
  public int CartId { get; set; }
  public int ProductId { get; set; }
  public int VariantId { get; set; }
  public int Quantity { get; set; }
  public int Price { get; set; }
  public Cart? Cart { get; set; }
  public ProductResponse? ProductDetails { get; set; }
  public VariantDto? SelectedVariant { get; set; }
  public Product? Product { get; set; }
}
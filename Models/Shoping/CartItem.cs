public class CartItem
{
  public int Id { get; set; }
  public int CartId { get; set; }
  public int VariantId { get; set; }
  public int ProductId { get; set; }
  public int CategoryId { get; set; }
  public int Quantity { get; set; }

  public Cart? Cart { get; set; }
  public Category? Category { get; set; }
  public Product? Product { get; set; }
  public Variant? Varient { get; set; }
}
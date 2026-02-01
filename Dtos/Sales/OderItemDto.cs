public class OrderItemDto
{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public int ProductID { get; set; }
  public string? ProductName { get; set; }
  public int Quantity { get; set; }
  public decimal UnitPrice { get; set; }
  public decimal Discount { get; set; }
  public decimal TotalPrice { get; set; }

  public ProductResponse? Product { get; set; }
  public OrderItemDto? Order { get; set; }

}
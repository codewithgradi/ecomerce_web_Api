public class Order
{
  public int Id { get; set; }
  public string? OrderNumber { get; set; }//ORD-2024-001
  public string? CustomerId { get; set; }
  public DateTime OrderDate { get; set; }
  public OrderStatus Status { get; set; }
  public decimal TotalAmount { get; set; }
  public Currency Currency { get; set; } = global::Currency.ZAR;
  public string? ShippingAddress { get; set; }
  public string? BillingAddress { get; set; }
  public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}


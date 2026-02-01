public class OrderDto
{
  public int Id { get; set; }
  public string? OrderNumber { get; set; }//ORD-2024-001
  public string? CustomerId { get; set; }//app user
  public DateTime OrderDate { get; set; }
  public DateTime ShippedAt { get; set; }
  public OrderStatus Status { get; set; }
  public decimal TotalAmount { get; set; }
  public Currency Currency { get; set; } = global::Currency.ZAR;
  public string? ShippingAddress { get; set; }
  public string? BillingAddress { get; set; }
  public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
  public AppUser? AppUser { get; set; }
  public PaymentDto? Payment { get; set; }
}


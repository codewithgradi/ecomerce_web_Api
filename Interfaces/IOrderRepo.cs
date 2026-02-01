
public interface IOrderRepo
{
  Task<List<OrderDto>> GetOrdersAsync(AdminQueryObject queryObject);
  Task<OrderDto?> GetOneOrder(int id);
  Task<bool> OrderExists(int id);
  Task<Order> CreateOrder(Order order);
  Task<OrderItem> CreateOrderItem(CreateOrderItemDto orderItemDto);
  Task<Payment> CreatePayment(int orderId, CreatePaymentDto paymentDto);
  Task<OrderDto?> ShipOrder(int id, ShipOrderDto shipOrder);
}
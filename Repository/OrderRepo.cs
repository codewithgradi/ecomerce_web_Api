using Microsoft.EntityFrameworkCore;

public class OrderRepo : IOrderRepo
{
  private readonly AppDbContext _context;
  public OrderRepo(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Order> CreateOrder(Order order)
  {
    await _context.Orders.AddAsync(order);
    await _context.SaveChangesAsync();
    return order;
  }

  public async Task<OrderItem> CreateOrderItem(CreateOrderItemDto orderItemDto)
  {
    var entry = await _context.OrderItems.AddAsync(orderItemDto.ToOrderItemFromCreate());
    await _context.SaveChangesAsync();
    return entry.Entity;
  }

  public async Task<Payment> CreatePayment(int orderId, CreatePaymentDto paymentDto)
  {
    var payment = paymentDto.ToPaymentFromCreate();
    payment.OrderId = orderId;
    var entry = await _context.Payments.AddAsync(payment);
    await _context.SaveChangesAsync();
    return entry.Entity;
  }

  public async Task<OrderDto?> GetOneOrder(int id)
  {
    var order = await _context.Orders
        .Include(o => o.OrderItems)
        .Include(o => o.Payment)
        .FirstOrDefaultAsync(c => c.Id == id);

    return order?.ToOrderDto();
  }

  public async Task<bool> OrderExists(int id)
  {
    return await _context.Orders.AnyAsync(c => c.Id == id);
  }

  public async Task<OrderDto?> ShipOrder(int id, ShipOrderDto shipOrder)
  {
    var order = await _context.Orders
        .Include(c => c.OrderItems)
        .Include(c => c.Payment)
        .FirstOrDefaultAsync(c => c.Id == id);

    if (order == null) return null;

    order.Status = shipOrder.OrderStatus;
    order.ShippedAt = shipOrder.ShippedAt;

    await _context.SaveChangesAsync();
    return order.ToOrderDto();
  }

  public async Task<List<OrderDto>> GetOrdersAsync(AdminQueryObject queryObject)
  {
    var orders = _context.Orders
        .Include(o => o.OrderItems)
        .Include(o => o.Payment)
        .AsQueryable();

    if (!string.IsNullOrWhiteSpace(queryObject.PaymentStatus))
    {
      if (Enum.TryParse<PaymentStatus>(queryObject.PaymentStatus, ignoreCase: true, out var statusEnum))
      {
        orders = orders.Where(o => o.Payment!.PaymentStatus == statusEnum);
      }
    }

    var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

    var result = await orders
        .Skip(skipNumber)
        .Take(queryObject.PageSize)
        .ToListAsync();

    return result.Select(s => s.ToOrderDto()).ToList();
  }

}
public static class OrderMappers
{
  public static Payment ToPaymentFromCreate(this CreatePaymentDto payment)
  {
    return new Payment
    {
      PaymentDate = payment.PaymentDate,
      Amount = payment.Amount,
      PaymentStatus = payment.PaymentStatus,
      TransactionId = payment.TransactionId
    };
  }
  public static OrderItem ToOrderItemFromCreate(this CreateOrderItemDto item)
  {
    return new OrderItem
    {
      ProductID = item.ProductID,
      ProductName = item.ProductName,
      Quantity = item.Quantity,
      UnitPrice = item.UnitPrice,
      TotalPrice = item.TotalPrice,
      Discount = item.Discount
    };
  }
  public static OrderDto ToOrderDto(this Order order)
  {
    return new OrderDto
    {
      Id = order.Id,
      OrderNumber = order.OrderNumber,
      CustomerId = order.CustomerId,
      OrderDate = order.OrderDate,
      Status = order.Status,
      TotalAmount = order.TotalAmount,
      Currency = order.Currency,
      BillingAddress = order.BillingAddress,
      ShippingAddress = order.ShippingAddress,
      ShippedAt = order.ShippedAt,
      OrderItems = order.OrderItems.Select(c => new OrderItemDto
      {
        Discount = c.Discount,
        Id = c.Id,
        ProductName = c.ProductName,
        ProductID = c.ProductID,
        OrderId = c.OrderId,
        TotalPrice = c.TotalPrice,
        UnitPrice = c.UnitPrice,
        Quantity = c.Quantity
      }).ToList(),

      Payment = order.Payment != null ? order.Payment.ToPaymentDto() : null
    };
  }

  public static OrderItemDto ToOrderItemDto(this OrderItem item)
  {
    return new OrderItemDto
    {
      Id = item.Id,
      ProductID = item.ProductID,
      ProductName = item.ProductName,
      Quantity = item.Quantity,
      UnitPrice = item.UnitPrice,
      TotalPrice = item.TotalPrice,
      Discount = item.Discount
    };
  }

  public static PaymentDto ToPaymentDto(this Payment payment)
  {
    return new PaymentDto
    {
      Id = payment.Id,
      PaymentDate = payment.PaymentDate,
      PaymentMethod = payment.PaymentMethod,
      Amount = payment.Amount,
      PaymentStatus = payment.PaymentStatus,
      TransactionId = payment.TransactionId
    };
  }
  public static Payment ToPaymentDto(this CreatePaymentDto payment)
  {
    return new Payment
    {
      PaymentDate = payment.PaymentDate,
      Amount = payment.Amount,
      PaymentStatus = payment.PaymentStatus,
      TransactionId = payment.TransactionId
    };
  }
  public static Order ToEntity(this OrderDto dto)
  {
    return new Order
    {
      Id = dto.Id,
      OrderNumber = dto.OrderNumber,
      CustomerId = dto.CustomerId,
      OrderDate = dto.OrderDate,
      Status = dto.Status,
      TotalAmount = dto.TotalAmount,
      Currency = dto.Currency,
      BillingAddress = dto.BillingAddress,
      ShippingAddress = dto.ShippingAddress,
      OrderItems = dto.OrderItems.Select(c => new OrderItem
      {
        Discount = c.Discount,
        Id = c.Id,
        ProductName = c.ProductName,
        ProductID = c.ProductID,
        OrderId = c.OrderId,
        TotalPrice = c.TotalPrice,
        UnitPrice = c.UnitPrice,
        Quantity = c.Quantity
      }).ToList(),
      Payment = dto.Payment?.ToPayment()
    };
  }
  public static Payment ToPayment(this PaymentDto payment)
  {
    return new Payment
    {
      Id = payment.Id,
      PaymentDate = payment.PaymentDate,
      PaymentMethod = payment.PaymentMethod,
      Amount = payment.Amount,
      PaymentStatus = payment.PaymentStatus,
      TransactionId = payment.TransactionId
    };
  }
}
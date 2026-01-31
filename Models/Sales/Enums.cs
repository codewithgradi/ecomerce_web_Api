public enum OrderStatus
{
  Pending,
  Processing,
  Shipped,
  Delivered,
  Cancelled
}

public enum Currency
{
  USD,
  ZAR,
  CAD
}

public enum PaymentMethod
{
  CreditCard,
  PayPal,
  Stripe,
  BankTrasfer
}
public enum PaymentStatus
{
  Pending,
  Succeded,
  Failed,
  Refunded,
}
public enum PaymentProvider
{
  Stripe,
  PayPal
}
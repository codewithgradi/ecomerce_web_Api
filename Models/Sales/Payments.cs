public class Payments
{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public DateTime PaymentDate { get; set; }
  public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Stripe;
  public string? TransactionId { get; set; }//from stripe
  public decimal Amount { get; set; }
  public PaymentStatus PaymentStatus { get; set; }
  public PaymentProvider Provider { get; set; }
  public string? Last4 { get; set; }//last four digits of card
}
public class CreatePaymentDto
{
  public int OrderId { get; set; }
  public DateTime PaymentDate { get; set; }
  public string? TransactionId { get; set; }
  public decimal Amount { get; set; }
  public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Succeded;
}
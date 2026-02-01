public class AdminQueryObject
{
  public string? PaymentStatus { get; set; }
  public int PageNumber { get; set; } = 1;
  public int PageSize { get; set; } = 50;
}
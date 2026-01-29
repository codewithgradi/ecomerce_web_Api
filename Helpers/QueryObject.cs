public class QueryObject
{
  public string? Brand { get; set; }
  public string? Price { get; set; }

  public bool IsDescendingPrice { get; set; } = false;
  public string? SortBy { get; set; }
  public int PageNumber { get; set; } = 1;
  public int PageSize { get; set; } = 20;
}
public class Portfolio
{
  public string? AppUserID { get; set; }
  public int ReviewId { get; set; }

  public AppUser? AppUser { get; set; }
  public Review? Review { get; set; }
}
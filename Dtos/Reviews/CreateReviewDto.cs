public class CreateReviewDto
{
  public int Id { get; set; }
  public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
  public string? Comment { get; set; }
  public int StarRating { get; set; }
  public string? UserId { get; set; }

}
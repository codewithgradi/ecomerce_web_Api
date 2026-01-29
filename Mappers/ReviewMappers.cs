public static class ReviewMappers
{
  public static ReviewDto ToReview(this Review review)
  {
    return new ReviewDto
    {
      Id = review.Id,
      Comment = review.Comment,
      CreatedOn = review.CreatedOn,
      UserId = review.UserId
    };
  }
  public static Review ToReviewFromCreate(this CreateReviewDto reviewDto)
  {
    return new Review
    {
      Id = reviewDto.Id,
      Comment = reviewDto.Comment,
      CreatedOn = reviewDto.CreatedOn,
      StarRating = reviewDto.StarRating,
      UserId = reviewDto.UserId
    };
  }
}
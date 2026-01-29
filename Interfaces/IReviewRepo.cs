public interface IReviewRepo
{
  Task<List<Review>> GetAllAsync(string userId);
  Task<Review> GetOneAsync(int ReviewId);
  Task<Review> CreateAsyn(Review create);
}
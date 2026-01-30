using Microsoft.EntityFrameworkCore;

public class ReviewRepo : IReviewRepo
{
  private readonly AppDbContext _context;
  public ReviewRepo(AppDbContext context)
  {
    _context = context;
  }
  public async Task<Review> CreateAsyn(Review create)
  {
    var review = await _context.Reviews.AddAsync(create);
    if (review == null) return null;
    await _context.SaveChangesAsync();
    return review.Entity;
  }

  public async Task<List<Review>> GetAllAsync(string id)
  {
    var reviews = await _context.Reviews.Where(c => c.UserId == id).ToListAsync();
    if (reviews.Count == 0) return new List<Review>();
    return reviews;
  }

  public async Task<Review> GetOneAsync(int id)
  {
    var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
    if (review == null) return null;
    return review;
  }
}
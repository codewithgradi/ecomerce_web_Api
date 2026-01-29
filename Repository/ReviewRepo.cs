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
    var reviews = _context.Reviews.Where(c => c.UserId == id);

    if (reviews.Count < 0) return null;
    return reviews.ToListAsync();
  }

  public async Task<Review> GetOneAsync(int id)
  {
    var review = await _context.Reviews.FirstOrDefault(x => x.Id == id);
    if (review == null) return null;
    return review;
  }
}
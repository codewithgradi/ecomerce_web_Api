using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class ReviewController : Controller
{
  private readonly IReviewRepo _reviewRepo;
  public ReviewController(IReviewRepo repo)
  {
    _reviewRepo = repo;
  }
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetAll([FromRoute] string id)
  {
    var reviews = await _reviewRepo.GetAllAsync(id);
    if (reviews == null) return NotFound("No reviews available");
    return Ok(reviews);
  }
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetOne([FromRoute] int id)
  {
    var review = await _reviewRepo.GetOneAsync(id);
    if (review == null) return NotFound("Not found");
    return Ok(review);
  }
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateReviewDto reviewDto)
  {
    var review = await _reviewRepo.CreateAsyn(reviewDto.ToReviewFromCreate());
    if (review == null) return BadRequest("Could not create review");
    return CreatedAtAction(nameof(GetOne), new { id = review.Id }, review);
  }
}
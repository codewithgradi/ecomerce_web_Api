using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase
{
  private readonly ICatalogRepo _cataloRepo;
  public CatalogController(ICatalogRepo catalogRepo)
  {
    _cataloRepo = catalogRepo;
  }
  [HttpGet]
  public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var products = await _cataloRepo.GetAllAsync(query);
    if (products == null) return BadRequest();
    if (products.Count == 0) return Ok("No products found");
    return Ok(products.Select(p => p.ToProduct()).ToList());
  }
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetOne([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var product = await _cataloRepo.GetByIdAsync(id);
    if (product == null) return NotFound("Product not found");
    return Ok(product);
  }
  [HttpDelete("{id:int}")]
  [Authorize]
  public async Task<IActionResult> Delete([FromRoute] int id)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var product = await _cataloRepo.DeleteAsync(id);
    if (product == null) return NotFound("Product does not exist.");
    return NoContent();
  }
  [HttpPut("{id:int}")]
  [Authorize]
  public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto update)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var product = await _cataloRepo.UpdateAsync(id, update);
    if (update == null) return BadRequest("Provide new price,Stock quantity and Size.");
    return Ok("Update was successful");
  }
  [HttpPost]
  [Authorize]
  public async Task<IActionResult> Create([FromRoute] CreateProductDto createProduct)
  {
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var product = await _cataloRepo.CreateAsync(createProduct);
    if (product == null) return BadRequest("Product not valid");
    return CreatedAtAction(nameof(GetOne), new { id = product.Id }, product);
  }
}
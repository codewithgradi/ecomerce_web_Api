using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class Cartcontroller : ControllerBase
{
  private readonly ICartRepo _cartRepo;
  private readonly UserManager<AppUser> _userManager;
  public Cartcontroller(UserManager<AppUser> userManager, ICartRepo cartRepo)
  {
    _userManager = userManager;
    _cartRepo = cartRepo;
  }
  [HttpGet]
  [Authorize]
  public async Task<IActionResult> GetCart()
  {
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId == null) Unauthorized();
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var cart = await _cartRepo.GetCartAsync(userId!);
    return Ok(cart);
  }
  [HttpDelete]
  [Authorize]
  public async Task<IActionResult> DeleteCart()
  {
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId == null) Unauthorized();
    if (!ModelState.IsValid) return BadRequest(ModelState);
    var cart = await _cartRepo.DeleteCartAsync(userId!);
    return NoContent();
  }
  [HttpPost]
  public async Task<IActionResult> AddToCart([FromBody] AddToCartDto cartDto)
  {
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (string.IsNullOrEmpty(userId)) return Unauthorized();
    var cartItem = await _cartRepo
    .AddItemToCartAsync(
      userId,

      cartDto.CartId,
      cartDto.VariantId,
      cartDto.Quantity,
      cartDto.ProductId
    );
    return Ok(cartItem);
  }
  [HttpDelete]
  public async Task<IActionResult> DeleteItemFromCart()
  {
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId == null) return Unauthorized();
    var cart = await _cartRepo.DeleteCartAsync(userId);
    return NoContent();
  }
}
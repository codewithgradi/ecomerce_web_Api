using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class CartRepo : ICartRepo
{
  private readonly AppDbContext _context;
  public CartRepo(AppDbContext context)
  {
    _context = context;
  }
  public async Task<CartItem> AddItemToCartAsync(
    string userId,
    CartItemDto cartItem,
    int cartId, int variantId, int quantity,
     int productId)
  {
    var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
    if (cart == null)
    {
      cart = new Cart { UserId = userId };
      await _context.Carts.AddAsync(cart);
      await _context.SaveChangesAsync();
    }
    //Checking if product already in cart
    var existingItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.VariantId == variantId);
    if (existingItem != null) { existingItem.Quantity += quantity; }
    else
    {
      var newItem = new CartItem
      {
        CartId = cartId,
        ProductId = productId,
        VariantId = variantId,
        Quantity = quantity,
        Price = 0,
      };
      await _context.CartItems.AddAsync(newItem);
      existingItem = newItem;
    }

    await _context.SaveChangesAsync();
    return existingItem!;
  }

  public async Task<bool> CartExist(string userId)
  {
    return await _context.Carts.AnyAsync(x => x.UserId == userId);
  }

  public async Task<CartDto> DeleteCartAsync(string UserId)
  {
    var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == UserId);
    if (cart == null) return null;
    _context.Carts.Remove(cart);
    await _context.SaveChangesAsync();
    return cart.ToCartDto();
  }

  public async Task<CartDto> GetCartAsync(string UserId)
  {
    var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == UserId);
    if (cart == null) return null;
    return cart.ToCartDto();
  }

  public async Task<CartItem> RemoveFromCartAsync(string UserId, int CartId)
  {
    var cartItem = await _context.CartItems
    .FirstOrDefaultAsync(
      c => c.CartId == CartId
      && c.Cart!.UserId == UserId
      );
    if (cartItem == null) return null!;
    return cartItem;
  }
}
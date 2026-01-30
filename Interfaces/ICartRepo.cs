public interface ICartRepo
{
  Task<CartDto> GetCartAsync(string UserId);
  Task<CartDto> DeleteCartAsync(string UserId);
  Task<CartItem> AddItemToCartAsync(
    string userId,
    CartItemDto cartItem,
    int cartId,
    int variantId,
    int quantity,
    int productId);
  Task<CartItem> RemoveFromCartAsync(string UserId, int CartId);
}
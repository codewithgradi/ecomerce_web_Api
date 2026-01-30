public static class CartMappers
{
  public static CartDto ToCartDto(this Cart cart)
  {
    return new CartDto
    {
      Id = cart.Id,
      UserId = cart.UserId,
      CreatedAt = cart.CreatedAt,
      UpdatedAt = cart.UpdatedAt,
      CartItems = cart.CartItems.Select(c => new CartItemDto
      {
        Id = c.Id,
        Price = c.Price,
        Quantity = c.Quantity,
        ProductId = c.ProductId,
        VariantId = c.VariantId,
        ProductDetails = c.Product?.ToProduct(),
        SelectedVariant = c.Product?.Variants
        .Where(v => v.Id == c.VariantId)
        .Select(v => new VariantDto
        {
          Id = v.Id,
          Size = v.Size,
          Color = v.Color,
          Price = (decimal)v.Price,
          Sku = v.Sku
        }).FirstOrDefault()
      }).ToList()
    };
  }
}
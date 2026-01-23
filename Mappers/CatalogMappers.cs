public static class CatalogMappers
{
  public static ProductResponse ToProduct(this Product product)
  {
    return new ProductResponse
    {
      Id = product.Id,
      Brand = product.Brand,
      CategoryName = product.Category?.DisplayName,
      CategorySlug = product.Category?.Slug,
      Variants = product.Variants.Select(v => new VariantDto
      {
        Id = v.Id,
        Sku = v.Sku,
        Color = v.Color,
        StockQuantity = v.StockQuantity,
        Price = (decimal)v.Price,
        Size = v.Size
      }).ToList()
    };
  }
}
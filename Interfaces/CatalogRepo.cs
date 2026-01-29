using Microsoft.AspNetCore.Mvc;

public interface ICatalogRepo
{
  Task<List<Product>> GetAllAsync(QueryObject query);
  Task<Product?> GetByIdAsync([FromRoute] int Id);
  Task<Product> CreateAsync([FromBody] CreateProductDto createProduct);
  Task<Product> DeleteAsync([FromRoute] int id);
  Task<Product?> UpdateAsync([FromRoute] int id, [FromBody] UpdateProductDto productDto);
  Task<bool> ProductExists(int id);
}
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CatalogRepo : ICatalogRepo
{
  private readonly AppDbContext _context;
  public CatalogRepo(AppDbContext context)
  {
    using var _ = _context = context;
  }

  public async Task<Product> CreateAsync(CreateProductDto createProduct)
  {
    await _context.Products.AddAsync(createProduct.ToProductFromCreate());
    await _context.SaveChangesAsync();
    return await _context.Products
    .Include(c => c.Category)
    .Include(c => c.Variants)
    .FirstAsync(x => x.Id == createProduct.Id);
  }

  public async Task<Product> DeleteAsync([FromRoute] int id)
  {
    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    if (product == null) return null;
    _context.Products.Remove(product);
    await _context.SaveChangesAsync();
    return product;
  }

  public async Task<List<Product>> GetAllAsync(QueryObject query)
  {
    var products = _context
    .Products.Include(c => c.Variants).AsQueryable();
    if (!string.IsNullOrWhiteSpace(query.Brand))
    {
      products = products.Where(p => p.Brand!.Contains(query.Brand));
    }
    if (string.Equals(query.SortBy, "Price",
    StringComparison.OrdinalIgnoreCase))
    {
      products = query.IsDescendingPrice ?
      products.OrderByDescending(s => s.Variants.Min(c => c.Price))
      : products.OrderBy(s => s.Variants.Min(c => c.Price));
    }

    var skipnumber = (query.PageNumber - 1) * query.PageSize;
    return await products.Skip(skipnumber).Take(query.PageSize).ToListAsync();
  }

  public async Task<Product?> GetByIdAsync(int Id)
  {
    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
    if (product == null) return null;
    return await _context.Products
    .Include(c => c.Category)
    .Include(c => c.Variants)
    .FirstOrDefaultAsync(x => x.Id == Id);
  }

  public Task<bool> ProductExists(int id)
  {
    return _context.Products.AnyAsync(x => x.Id == id);
  }

  public async Task<Product?> UpdateAsync(int id, UpdateProductDto updateProduct)
  {
    var product = await _context.Products.Include(c => c.Variants).FirstOrDefaultAsync(x => x.Id == id);
    if (product == null) return null;
    var variant = await _context.Variants.FirstOrDefaultAsync(x => x.Id == id);
    if (variant != null)
    {
      variant.Size = updateProduct.Size;
      variant.StockQuantity = updateProduct.StockQuantity;
      variant.Price = updateProduct.Price;
    }
    await _context.SaveChangesAsync();
    return product;
  }
}
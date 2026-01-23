public class Category
{
  public int Id { get; set; }
  public string? Slug { get; set; }//for url like /kitchen-applience-frontend
  public string? DisplayName { get; set; }

  //Allows easy query like category.Products 
  public ICollection<Product> Products { get; set; }
   = new List<Product>();

}
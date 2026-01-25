using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
  {

  }
  //Tables
  DbSet<Product> Products { get; set; }
  DbSet<Category> Categories { get; set; }
  DbSet<Variant> Variants { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    //Relationships: Category -> product
    builder.Entity<Product>()
    .HasOne(p => p.Category)
    //for ICollection<Product>
    .WithMany(c => c.Products)
    .HasForeignKey(p => p.CategoryId)
    //prevents accidental category deletion
    .OnDelete(DeleteBehavior.Restrict);

    //Relationships: Category -> product
    builder.Entity<Variant>()
    .HasOne(v => v.Product)
    //points to ICollection
    .WithMany(p => p.Variants)
    .HasForeignKey(v => v.ProductId)
    //deletes product and its variants
    .OnDelete(DeleteBehavior.Cascade);


    //Identity Roles
    List<IdentityRole> roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Id = "fab4fac1-c546-41de-aebc-a14da401b7e4", // Static GUID
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = "c7b013f0-5201-4317-abd8-c211f91b7330", // Static GUID
            Name = "User",
            NormalizedName = "USER"
        }
    };
    builder.Entity<IdentityRole>().HasData(roles);
  }
}
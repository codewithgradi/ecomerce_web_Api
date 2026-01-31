using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
  {

  }
  //Tables
  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Variant> Variants { get; set; }
  public DbSet<Review> Reviews { get; set; }
  public DbSet<Cart> Carts { get; set; }
  public DbSet<CartItem> CartItems { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Payment> Payments { get; set; }

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

    builder.Entity<Review>()
    .HasOne(c => c.AppUser)
    .WithMany(c => c.Reviews)
    .HasForeignKey(c => c.UserId);

    builder.Entity<CartItem>()
    .HasOne(c => c.Cart)
    .WithMany(c => c.CartItems)
    .HasForeignKey(c => c.CartId)
    //cart deleted? then cartitems goes with it
    .OnDelete(DeleteBehavior.Cascade)
    ;

    builder.Entity<OrderItem>()
    .HasOne(c => c.Order)
    .WithMany(c => c.OrderItems)
    .HasForeignKey(c => c.OrderId)
    .OnDelete(DeleteBehavior.Restrict);


    //One to one relationships
    builder.Entity<Payment>()
    .HasOne(c => c.Order)
    .WithOne(c => c.Payment)
    .HasForeignKey<Payment>(c => c.OrderId);

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
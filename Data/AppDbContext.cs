using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<AppUser>
{
  public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
  {

  }
  //Tables

}
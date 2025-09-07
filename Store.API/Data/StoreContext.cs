using Microsoft.EntityFrameworkCore;
using Store.API.Entities;

namespace Store.API.Data
{
  public class StoreContext(DbContextOptions options):DbContext(options)
  {
    public DbSet<Product> Products { get; set; }
  }
}

using ItemAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ItemAPI.Controllers.Data
{
    public class ItemDbContext(DbContextOptions<ItemDbContext> options) : DbContext(options)
    {
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemDetail> ItemDetails => Set<ItemDetail>();
    }
}

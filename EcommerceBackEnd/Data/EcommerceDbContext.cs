using EcommerceBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackEnd.Data
{
    public class EcommerceDbContext: DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

using Autoglass.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }

    }
}

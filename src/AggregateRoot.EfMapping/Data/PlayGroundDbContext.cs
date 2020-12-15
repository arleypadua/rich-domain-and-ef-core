using AggregateRoot.EfMapping.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace AggregateRoot.EfMapping.Data
{
    public class PlayGroundDbContext : DbContext
    {
        public PlayGroundDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Order> Orders { get; set; }
    }
}
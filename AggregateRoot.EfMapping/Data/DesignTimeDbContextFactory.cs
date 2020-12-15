using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AggregateRoot.EfMapping.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PlayGroundDbContext>
    {
        public PlayGroundDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder()
                .UseSqlServer(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=PlayGroundDb;Integrated Security=True");
            return new PlayGroundDbContext(options.Options);
        }
    }
}
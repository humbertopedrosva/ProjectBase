using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectBase.Infra.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            PreventDeleteInCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void PreventDeleteInCascade(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}

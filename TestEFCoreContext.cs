using Microsoft.EntityFrameworkCore;

namespace TestEFCore
{
    public sealed class TestEFCoreContext : DbContext
    {
        public TestEFCoreContext(DbContextOptions<TestEFCoreContext> builderOptions) : base(builderOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity Types
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

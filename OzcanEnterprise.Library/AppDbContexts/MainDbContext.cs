using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OzcanEnterprise.Library.Entities;

namespace OzcanEnterprise.Library.AppDbContexts
{
    public class MainDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var configuration = new ConfigurationBuilder().AddJsonFile("C:\\Users\\ybroz\\source\\repos\\OzcanEnterprise\\OzcanEnterprise.Api\\appsettings.json").Build();
            var connStr = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connStr, options =>
            {
                options.CommandTimeout(5_000);
                options.EnableRetryOnFailure(maxRetryCount: 5);
            });
        }
    }

}

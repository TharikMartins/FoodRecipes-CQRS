namespace FoodRecipes.CQRS.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;
    using FoodRecipes.CQRS.Domain;

    public class FoodRecipesContext : DbContext
    {
        public FoodRecipesContext(DbContextOptions<FoodRecipesContext> context) : base(context) { }
        public DbSet<FoodRecipe> FoodRecipes => Set<FoodRecipe>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FoodRecipe>()
               .HasKey(m => m.Id);

            builder.Entity<Ingredient>()
               .HasKey(m => m.Id);
        }
    }
}

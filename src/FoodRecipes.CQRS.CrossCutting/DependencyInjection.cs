namespace FoodRecipes.CQRS.CrossCutting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FoodRecipes.CQRS.Infrastructure.Context;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Infrastructure.Repositories;
using FoodRecipes.CQRS.Domain;


public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        return services.AddScoped<IRepository<FoodRecipe>, FoodRecipesRepository>()
        .AddDbContext<FoodRecipesContext>(context => context.UseInMemoryDatabase(databaseName: "FoodRecipeDatabase"));
    }
}
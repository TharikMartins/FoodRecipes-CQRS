namespace FoodRecipes.CQRS.Infrastructure.Repositories;

using FoodRecipes.CQRS.Domain;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class FoodRecipesRepository : IRepository<FoodRecipe>
{
    private readonly FoodRecipesContext _context;
    public FoodRecipesRepository(FoodRecipesContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FoodRecipe>> Get()
    {
        return await _context.FoodRecipes
        .Include(x => x.Ingredients)
        .AsNoTracking()
        .ToListAsync();
    }

    public async Task<FoodRecipe?> Get(int Id)
    {
        return await _context.FoodRecipes
        .Include(x => x.Ingredients)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == Id);
    }


    public async Task<bool> Insert(FoodRecipe model)
    {
        await _context.FoodRecipes
        .AddAsync(model);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(FoodRecipe model)
    {
        if (await this.Get(model.Id) is null) return false;

        _context.FoodRecipes
        .Update(model);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int Id)
    {
        FoodRecipe? model =
        await this.Get(Id);

        if (model is null) return false;

        _context.Remove(model);

        return await _context.SaveChangesAsync() > 0;
    }
}
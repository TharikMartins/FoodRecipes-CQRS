namespace FoodRecipes.CQRS.Application.Responses;

public record FoodRecipeViewModel(int Id, string? Name, string? Instructions, ICollection<IngredientViewModel>? Ingredients)
{
    public FoodRecipeViewModel() : this(default, default, default, default) { }
}
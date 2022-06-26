namespace FoodRecipes.CQRS.Application.Responses;

public record IngredientViewModel(int Id, string? Name, int Quantity)
{
    public IngredientViewModel() : this(default, default, default) { }
}
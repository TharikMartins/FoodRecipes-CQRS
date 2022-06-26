namespace FoodRecipes.CQRS.Application.Commands.UpdateFoodRecipe;

public record UpdateIngredientCommand(int Id, string? Name, int Quantity);
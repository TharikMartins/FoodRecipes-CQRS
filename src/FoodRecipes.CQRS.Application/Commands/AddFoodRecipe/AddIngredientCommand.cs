namespace FoodRecipes.CQRS.Application.Commands.AddFoodRecipe;

public record AddIngredientCommand(string? Name, int Quantity);
namespace FoodRecipes.CQRS.Application.Commands.UpdateFoodRecipe;
using FoodRecipes.CQRS.Application.Responses;
using MediatR;

public record UpdateFoodRecipeCommand(int Id, string? Name, string? Instructions, List<UpdateIngredientCommand>? Ingredients)
 : IRequest<TransactionResponse>;
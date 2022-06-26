namespace FoodRecipes.CQRS.Application.Commands.AddFoodRecipe;
using FoodRecipes.CQRS.Application.Responses;
using MediatR;
public record AddFoodRecipeCommand(string? Name, string? Instructions, List<AddIngredientCommand>? Ingredients) : IRequest<TransactionResponse>;
namespace FoodRecipes.CQRS.Application.Commands.DeleteFoodRecipeById;

using FoodRecipes.CQRS.Application.Responses;
using MediatR;

public record DeleteFoodRecipeByIdCommand(int Id) : IRequest<TransactionResponse>;
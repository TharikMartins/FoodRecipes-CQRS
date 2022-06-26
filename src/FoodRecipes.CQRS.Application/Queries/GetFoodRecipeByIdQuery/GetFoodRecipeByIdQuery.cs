namespace FoodRecipes.CQRS.Application.Queries.GetFoodRecipeByIdQuery;

using FoodRecipes.CQRS.Application.Responses;
using MediatR;

public record GetFoodRecipeByIdQuery(int Id) : IRequest<FoodRecipeViewModel>
{
   
}
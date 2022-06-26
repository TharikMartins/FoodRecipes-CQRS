namespace FoodRecipes.CQRS.Application.Queries.GetAllFoodRecipesQuery;

using FoodRecipes.CQRS.Application.Responses;
using MediatR;

public record GetAllFoodRecipesQuery : IRequest<IEnumerable<FoodRecipeViewModel>> 
{

}
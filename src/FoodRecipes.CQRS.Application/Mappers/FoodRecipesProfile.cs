namespace FoodRecipes.CQRS.Application.Mappers;

using AutoMapper;
using FoodRecipes.CQRS.Application.Commands.AddFoodRecipe;
using FoodRecipes.CQRS.Application.Commands.UpdateFoodRecipe;
using FoodRecipes.CQRS.Application.Responses;
using FoodRecipes.CQRS.Domain;
public class FoodRecipesProfile : Profile
{
    public FoodRecipesProfile()
    {
        CreateMap<AddFoodRecipeCommand, FoodRecipe>();
        CreateMap<AddIngredientCommand, Ingredient>();

        CreateMap<FoodRecipe, FoodRecipeViewModel>();
        CreateMap<Ingredient, IngredientViewModel>();

        CreateMap<UpdateFoodRecipeCommand, FoodRecipe>();
        CreateMap<UpdateIngredientCommand, Ingredient>();
    }
}
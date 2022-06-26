namespace FoodRecipes.CQRS.Application.Handlers;

using FoodRecipes.CQRS.Application.Commands.DeleteFoodRecipeById;
using FoodRecipes.CQRS.Application.Responses;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Domain;
using MediatR;

public class DeleteFoodRecipeByIdHandler : IRequestHandler<DeleteFoodRecipeByIdCommand, TransactionResponse>
{
    private readonly IRepository<FoodRecipe> _repository;

    public DeleteFoodRecipeByIdHandler(IRepository<FoodRecipe> repository)
    {
        _repository = repository;
    }

    public async Task<TransactionResponse> Handle(DeleteFoodRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        return new TransactionResponse(Success: await _repository.Delete(request.Id));
    }
}
namespace FoodRecipes.CQRS.Application.Handlers;

using FoodRecipes.CQRS.Application.Commands.UpdateFoodRecipe;
using FoodRecipes.CQRS.Application.Responses;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Domain;

using MediatR;
using AutoMapper;
public class UpdateFoodRecipeHandler : IRequestHandler<UpdateFoodRecipeCommand, TransactionResponse>
{
    private readonly IRepository<FoodRecipe> _repository;
    private readonly IMapper _mapper;

    public UpdateFoodRecipeHandler(IRepository<FoodRecipe> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransactionResponse> Handle(UpdateFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        return new TransactionResponse(Success: await _repository.Update(_mapper.Map<FoodRecipe>(request)));
    }
}
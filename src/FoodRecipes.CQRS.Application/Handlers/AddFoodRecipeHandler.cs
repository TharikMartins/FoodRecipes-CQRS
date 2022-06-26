namespace FoodRecipes.CQRS.Application.Handlers;

using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Domain;
using AutoMapper;
using MediatR;
using FoodRecipes.CQRS.Application.Commands.AddFoodRecipe;
using FoodRecipes.CQRS.Application.Responses;

public class AddFoodRecipeHandler : IRequestHandler<AddFoodRecipeCommand, TransactionResponse>
{
    private readonly IRepository<FoodRecipe> _repository;
    private readonly IMapper _mapper;

    public AddFoodRecipeHandler(IRepository<FoodRecipe> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransactionResponse> Handle(AddFoodRecipeCommand request, CancellationToken cancellationToken)
    {
        return new TransactionResponse(Success: await _repository.Insert(_mapper.Map<FoodRecipe>(request)));
    }
}
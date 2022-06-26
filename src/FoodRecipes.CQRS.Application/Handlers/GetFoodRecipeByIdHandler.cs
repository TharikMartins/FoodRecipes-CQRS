namespace FoodRecipes.CQRS.Application.Handlers;

using AutoMapper;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Application.Queries.GetFoodRecipeByIdQuery;
using FoodRecipes.CQRS.Application.Responses;
using FoodRecipes.CQRS.Domain;
using MediatR;


public class GetFoodRecipeByIdHandler : IRequestHandler<GetFoodRecipeByIdQuery, FoodRecipeViewModel?>
{
    private readonly IRepository<FoodRecipe> _repository;
    private readonly IMapper _mapper;
    public GetFoodRecipeByIdHandler(IRepository<FoodRecipe> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FoodRecipeViewModel?> Handle(GetFoodRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<FoodRecipeViewModel>(await _repository.Get(request.Id));
    }
}
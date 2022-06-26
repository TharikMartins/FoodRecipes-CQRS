namespace FoodRecipes.CQRS.Application.Handlers;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodRecipes.CQRS.Application.Interfaces;
using FoodRecipes.CQRS.Application.Queries.GetAllFoodRecipesQuery;
using FoodRecipes.CQRS.Application.Responses;
using FoodRecipes.CQRS.Domain;
using MediatR;
public class GetAllFoodRecipesHandler : IRequestHandler<GetAllFoodRecipesQuery, IEnumerable<FoodRecipeViewModel>>
{
    private readonly IRepository<FoodRecipe> _repository;
    private readonly IMapper _mapper;

    public GetAllFoodRecipesHandler(IRepository<FoodRecipe> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FoodRecipeViewModel>> Handle(GetAllFoodRecipesQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<FoodRecipeViewModel>>(await _repository.Get());
    }
}
namespace FoodRecipes.CQRS.Api.Controllers;

using FoodRecipes.CQRS.Application.Commands.AddFoodRecipe;
using FoodRecipes.CQRS.Application.Commands.UpdateFoodRecipe;
using FoodRecipes.CQRS.Application.Commands.DeleteFoodRecipeById;
using FoodRecipes.CQRS.Application.Queries.GetAllFoodRecipesQuery;
using FoodRecipes.CQRS.Application.Queries.GetFoodRecipeByIdQuery;
using FoodRecipes.CQRS.Application.Responses;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FoodRecipesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodRecipesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodRecipeViewModel>>> Get()
    {
        return Ok(await _mediator.Send(new GetAllFoodRecipesQuery()));
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<FoodRecipeViewModel>> Get(int Id)
    {
        return Ok(await _mediator.Send(new GetFoodRecipeByIdQuery(Id: Id)));
    }

    [HttpPost]
    public async Task<ActionResult<TransactionResponse>> Post(AddFoodRecipeCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult<TransactionResponse>> Put(UpdateFoodRecipeCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<TransactionResponse>> Delete(int Id)
    {
        TransactionResponse response = await _mediator.Send(new DeleteFoodRecipeByIdCommand(Id: Id));
        return response.Success ? Ok(response) : NotFound();
    }
}
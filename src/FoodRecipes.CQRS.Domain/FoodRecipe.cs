namespace FoodRecipes.CQRS.Domain
{
    public record FoodRecipe(int Id, string? Name, string? Instructions, ICollection<Ingredient>? Ingredients)
    {
        public FoodRecipe() : this(default, default, default, default) { }
    }

}
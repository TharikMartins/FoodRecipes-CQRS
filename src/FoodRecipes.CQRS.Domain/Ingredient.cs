namespace FoodRecipes.CQRS.Domain
{
    public record Ingredient(int Id, string? Name, int Quantity)
    {
        public Ingredient() : this(default, default, default) { }
    }
}

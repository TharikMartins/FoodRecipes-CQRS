namespace FoodRecipes.CQRS.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T?> Get(int Id);
        Task<bool> Insert(T Model);
        Task<bool> Update(T Model);
        Task<bool> Delete(int Id);
    }
}
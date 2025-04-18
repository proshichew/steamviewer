namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T game);
        Task<T?> Get(int id);
        Task Delete(int id);
    }
}
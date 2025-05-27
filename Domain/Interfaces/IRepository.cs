namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T item, CancellationToken cancellationToken);
        Task<T?> Get(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);

        Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    }
}
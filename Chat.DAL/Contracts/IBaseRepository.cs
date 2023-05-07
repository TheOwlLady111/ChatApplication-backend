namespace Chat.DAL.Contracts;

public interface IBaseRepository<T>
{
    Task<T> GetAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChanges();
}
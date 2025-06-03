using System.Linq.Expressions;


namespace blog.Core.Interfaces
{
    public interface IReposetory<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T?> GetAsync(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false);

        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);

    }
}

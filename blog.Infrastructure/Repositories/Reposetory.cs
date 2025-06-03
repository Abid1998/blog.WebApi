using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace blog.Infrastructure.Repositories
{
    public class Reposetory<T> : IReposetory<T> where T : class
    {
      /*******************************************************************************************************
      *******************************************************************************************************
      |                              All Comman Functions  Reposetory                                        |
      *******************************************************************************************************
      *******************************************************************************************************/

        private readonly ApplicationDbContext dbContext;
        internal DbSet<T> dbSet;

        public Reposetory(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        //*******************************************************************************************************
        //                               Create Async Method                                    
        //*******************************************************************************************************
        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        //*******************************************************************************************************
        //                               Delete Async Method                                    
        //*******************************************************************************************************
        public Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask; // Simulates asynchronous behavior
        }

        //*******************************************************************************************************
        //                               All Delete Async Method                                    
        //*******************************************************************************************************
        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return Task.CompletedTask; // Simulates asynchronous behavior
        }


        //*******************************************************************************************************
        //                               Get All Async Method                                    
        //*******************************************************************************************************
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }


        //*******************************************************************************************************
        //                               Get BY id Async Method                                    
        //*******************************************************************************************************
        public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked == true)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

    }
}

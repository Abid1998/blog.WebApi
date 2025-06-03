using blog.Core.Entities;
namespace blog.Core.Interfaces
{
    public interface ICategoriesRepository: IReposetory<Categories>
    {
        Task<Categories> UpdateCategoriesAsync(int category_id, Categories obj); // Return the updated category
    }
}

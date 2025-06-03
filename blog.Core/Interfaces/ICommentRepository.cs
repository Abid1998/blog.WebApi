using blog.Core.Entities;
namespace blog.Core.Interfaces
{
    public interface ICommentRepository:IReposetory<Comment>
    {
        Task<Comment> UpdateCommentAsync(int commnet_id, Comment obj); // Return the updated category
    }
}

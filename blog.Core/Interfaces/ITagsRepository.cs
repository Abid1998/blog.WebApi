using blog.Core.Entities;
namespace blog.Core.Interfaces
{
    public interface ITagsRepository: IReposetory<Tags>
    {
        Task<Tags> UpdateTagsAsync(int tag_id, Tags obj);
    }
}

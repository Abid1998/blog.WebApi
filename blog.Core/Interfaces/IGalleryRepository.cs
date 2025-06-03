using blog.Core.Entities;

namespace blog.Core.Interfaces
{
    public interface IGalleryRepository:IReposetory<Gallery>
    {
        Task<Gallery> UpdateGalleryAsync(int gallete_id, Gallery obj);
    }
}

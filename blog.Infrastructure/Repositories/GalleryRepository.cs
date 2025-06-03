using blog.Core.Entities;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace blog.Infrastructure.Repositories
{
    public class GalleryRepository : Reposetory<Gallery>, IGalleryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public GalleryRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Gallery> UpdateGalleryAsync(int gallete_id, Gallery obj)
        {
            var galleryModel = await dbContext.TblGallery.FirstOrDefaultAsync(x => x.gallery_id == gallete_id);
            try
            {
              
                if (galleryModel != null)
                {
                    galleryModel.gallery_img = obj.gallery_img;
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error updating gallery", ex);
            }
            
            return galleryModel;
        }
    }
}

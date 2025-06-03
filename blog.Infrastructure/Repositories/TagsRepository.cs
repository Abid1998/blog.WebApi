using blog.Core.Entities;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace blog.Infrastructure.Repositories
{
    public class TagsRepository : Reposetory<Tags>, ITagsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TagsRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Tags> UpdateTagsAsync(int tag_id, Tags obj)
        {
           var tagModel= await dbContext.TblTags.FirstOrDefaultAsync(x=>x.tag_id==tag_id);
            try
            {
                if (tagModel.tag_id != 0)
                {
                    tagModel.tag_name=obj.tag_name;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something want wrong", ex);
            }

            return tagModel;
        }
    
    }
}

using blog.Core.Entities;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace blog.Infrastructure.Repositories
{
    public class CategoriesRepository : Reposetory<Categories>, ICategoriesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        //*******************************************************************************************
        //                              Update Category- Method
        //*******************************************************************************************

        public async Task<Categories> UpdateCategoriesAsync(int category_id, Categories obj)
        {
            // Fetch the existing business profile by id
            var categoriesModal= await dbContext.TblCategories.FirstOrDefaultAsync(x => x.category_id == category_id);
            try
            {
                // Update properties (only if provided)
                if (categoriesModal != null)
                {
                    if (obj.category_name != "")
                    {
                        categoriesModal.category_name = obj.category_name;
                    }

                    if (obj.category_slug != "")
                    {
                        categoriesModal.category_slug = obj.category_slug;
                    }

                    if (obj.category_meta != "")
                    {
                        categoriesModal.category_meta = obj.category_meta;
                    }

                    if (obj.category_description != "")
                    {
                        categoriesModal.category_description = obj.category_description;
                    }

                    if (obj.category_image != "")
                    {
                        categoriesModal.category_image = obj.category_image;
                    }

                    if (obj.category_type != 0)
                    {
                        categoriesModal.category_type = obj.category_type;
                    }
                    categoriesModal.status = obj.status;
                    categoriesModal.updated_by = obj.updated_by;
                    categoriesModal.updated_at = obj.updated_at;
                }
                // Save changes to the database
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception here (e.g., using a logging framework)
                throw new InvalidOperationException("Error updating business profile", ex);
            }

            //return categoriesModal; // Return the updated profile
            if (categoriesModal == null)
            throw new InvalidOperationException("categoriesModal was not initialized.");
            return categoriesModal;

        }

    }
}

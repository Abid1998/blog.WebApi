using AutoMapper;
using blog.Core.DTOs.TutorialDtos;
using blog.Core.DTOs.WebStoryDtos;
using blog.Core.Entities;
using blog.Core.Enums;
using blog.Core.Helpers;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace blog.Infrastructure.Repositories
{
    public class TutorialRepository : Reposetory<Tutorial>, ITutorialRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public TutorialRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        ///  update data
        /// </summary>
        public async Task<TutorialDto> UpdateTutorialAsync(int tutorial_id, TutorialUpdateDto obj)
        {
            var tutorialModel = await dbContext.TblTutorial.Include(x => x.TutorialDetails).Include(x => x.tags).Include(x => x.galleries).FirstOrDefaultAsync(x => x.tutorial_id == tutorial_id);

            if (tutorialModel == null) throw new InvalidOperationException("Tutorial not found");

            try
            {
                // Update basic fields
                if (!string.IsNullOrWhiteSpace(obj.tutorial_title)) tutorialModel.tutorial_title = obj.tutorial_title;

                if (!string.IsNullOrWhiteSpace(obj.tutorial_slug)) tutorialModel.tutorial_slug = obj.tutorial_slug;

                if (!string.IsNullOrWhiteSpace(obj.tutorial_meta)) tutorialModel.tutorial_meta = obj.tutorial_meta;

                if (!string.IsNullOrWhiteSpace(obj.schedule)) tutorialModel.schedule = obj.schedule;

                if (obj.category_id > 0) tutorialModel.category_id = obj.category_id;

                if (obj.tutorial_image != null) tutorialModel.tutorial_image = obj.tutorial_image_path; 

                tutorialModel.status = obj.status; 
                tutorialModel.updated_by = obj.updated_by;

                // Update tutorial descriptions and languages
                if (obj.tutorial_descriptions?.Any() == true && obj.languages?.Any() == true)
                {
                    dbContext.TblTutorial_Details.RemoveRange(tutorialModel.TutorialDetails ?? new List<Tutorial_Details>());

                    tutorialModel.TutorialDetails = obj.tutorial_descriptions.Select((desc, index) => new Tutorial_Details
                        {
                            tutorial_description = desc,
                            languages = obj.languages.ElementAtOrDefault(index) ?? string.Empty
                        }).ToList();
                }

                // Update tags
                if (obj.tag_name?.Any() == true)
                {
                    dbContext.TblTags.RemoveRange(tutorialModel.tags ?? new List<Tags>());
                    tutorialModel.tags = obj.tag_name.Select(tag => new Tags { tag_name = tag }).ToList();
                }

                // Update galleries
                if (obj.galleries_paths?.Any() == true)
                {
                    dbContext.TblGallery.RemoveRange(tutorialModel.galleries ?? new List<Gallery>());
                    tutorialModel.galleries = obj.galleries_paths.Select(path => new Gallery { gallery_img = path }).ToList();
                }

                // Save changes
                await dbContext.SaveChangesAsync();

                return mapper.Map<TutorialDto>(tutorialModel);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something went wrong during update", ex);
            }
        }


    }
}

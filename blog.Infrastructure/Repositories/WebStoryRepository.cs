using AutoMapper;
using blog.Core.DTOs;
using blog.Core.DTOs.WebStoryDtos;
using blog.Core.Entities;
using blog.Core.Helpers;
using blog.Core.Interfaces;
using blog.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace blog.Infrastructure.Repositories
{
    public class WebStoryRepository : Reposetory<WebStory>, IWebStoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public WebStoryRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <summary>
        ///  update data
        /// </summary>
        
        public async Task<WebStoryDto> UpdateWebStoryAsync(int story_id, WebStoryUpdateDto dto)
        {
            var existingStory = await dbContext.TblWebStory.Include(ws => ws.Pages).FirstOrDefaultAsync(ws => ws.story_id == story_id);

            if (existingStory == null) throw new InvalidOperationException("Web Story not found");

            // Delete existing pages
            if (existingStory.Pages != null && existingStory.Pages.Any())
            {
                dbContext.TblWebStoryPage.RemoveRange(existingStory.Pages);
                await dbContext.SaveChangesAsync();
            }

            // Handle cover image upload
            if (dto.cover_image != null && dto.cover_image.Length > 0)
            {
                var coverPath = await FileUpload.SaveFileAsync(dto.cover_image, "upload");
                existingStory.cover_image_url = coverPath;
            }

            // Update basic fields
            existingStory.title = dto.title;
            existingStory.slug = dto.slug;
            existingStory.schedule = dto.schedule;
            existingStory.status = dto.status;
            existingStory.updated_by = dto.updated_by;

            // Create new pages
            var newPages = new List<WebStoryPage>();
            int count = Math.Max(dto.images?.Count ?? 0, dto.text_content?.Count ?? 0);

            for (int i = 0; i < count; i++)
            {
                string? imagePath = null;
                string? text = null;

                if (dto.images != null && i < dto.images.Count && dto.images[i]?.Length > 0)
                    imagePath = await FileUpload.SaveFileAsync(dto.images[i], "upload");

                if (dto.text_content != null && i < dto.text_content.Count)
                    text = dto.text_content[i];

                if (!string.IsNullOrEmpty(imagePath) || !string.IsNullOrEmpty(text))
                {
                    newPages.Add(new WebStoryPage
                    {
                        story_id = existingStory.story_id,
                        image_url = imagePath,
                        text_content = text
                    });
                }
            }

            // Save new pages
            if (newPages.Any())
            {
                dbContext.TblWebStoryPage.AddRange(newPages);
            }

            try
            {
                await dbContext.SaveChangesAsync();
                return mapper.Map<WebStoryDto>(existingStory);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving changes: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw new InvalidOperationException("Failed to update web story.", ex);
            }
        }

    }
}


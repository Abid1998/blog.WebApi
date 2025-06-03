using AutoMapper;
using blog.Core.DTOs;
using blog.Core.DTOs.WebStoryDtos;
using blog.Core.Entities;
using blog.Core.Helpers;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebStoryController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public WebStoryController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }


        /// <summary>
        ///  GET All: api/Category
        /// </summary>

        [HttpGet("GetAllWebStory")]
        public async Task<IActionResult> GetAllWebStory()
        {
            var modalWebStory = await unitofWork.WebStoryRepository.GetAllAsync();
            return Ok(mapper.Map<List<WebStoryDto>>(modalWebStory));
        }

        /// <summary>
        ///  GET By Id: api/Category Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetWebStory/{id}")]
        public async Task<IActionResult> GetWebStory(int id)
        {
            try
            {
                var modalWebStory = await unitofWork.WebStoryRepository.GetAsync(x => x.story_id == id);
                if (modalWebStory == null) throw new InvalidOperationException("Web Story not found");
                // Map DBO to Domain and return the data with HTTP 200 status
                var webStoryDto = mapper.Map<WebStoryDto>(modalWebStory);
                return Ok(webStoryDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        [HttpGet("GetWebStoryBySlug/{slug}")]
        public async Task<IActionResult> GetWebStoryBySlug(string? slug)
        {
            try
            {
                var modalWebStory = await unitofWork.WebStoryRepository.GetAsync(x => x.slug == slug);
                if (modalWebStory == null) throw new InvalidOperationException("Web Story not found");
                // Map DBO to Domain and return the data with HTTP 200 status
                var webStoryDto = mapper.Map<WebStoryDto>(modalWebStory);
                return Ok(webStoryDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Category
        /// </summary>

        [HttpDelete("DeleteByIdWebStory/{id}")]
        public async Task<IActionResult> DeleteByIdWebStory([FromRoute] int id)
        {
            try
            {
                // Fetch single data using the repository
                var modalWebStory = await unitofWork.WebStoryRepository.GetAsync(x => x.story_id == id);
                if (modalWebStory == null) throw new InvalidOperationException("Web Story not found");
                await unitofWork.WebStoryRepository.DeleteAsync(modalWebStory);   // Delete the Web Story By Id 
                await unitofWork.Save();
                return Ok(new { message = "Web Story deleted successfully!." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Deleted All Category
        /// </summary>

        [HttpDelete("DeleteAllWebStory")]
        public async Task<IActionResult> DeleteAllWebStory()
        {
            try
            {
                // Fetch all Web Stroy from the database
                var modalWebStory = await unitofWork.WebStoryRepository.GetAllAsync();
                if (modalWebStory == null) throw new InvalidOperationException("Web Story not found");
                await unitofWork.WebStoryRepository.DeleteRangeAsync(modalWebStory);
                await unitofWork.Save();
                return Ok(new { message = "Web Story updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  POST: api/Category
        /// </summary>

        [HttpPost("CreateWebStory")]
        public async Task<IActionResult> CreateWebStory([FromForm] WebStoryAddDto dto)
        {
            try
            {
                // Map and prepare webStory
                var webStory = mapper.Map<WebStory>(dto);

                // Generate slug (keep as is)
                string baseText = string.IsNullOrWhiteSpace(dto.slug) ? dto.title ?? string.Empty : dto.slug;
                dto.slug = await SlugGenerator.GenerateUniqueSlugAsync(baseText, async (baseSlug) =>
                {
                    var existingSlugs = await unitofWork.WebStoryRepository.GetAllAsync(x => (x.slug ?? "").StartsWith(baseSlug));
                    return existingSlugs.Select(x => x.slug ?? "").ToList();
                });

                // Upload cover image
                string? coverImagePath = null;
                if (dto.cover_image_url != null && dto.cover_image_url.Length > 0)
                    coverImagePath = await FileUpload.SaveFileAsync(dto.cover_image_url, "upload");

                webStory.cover_image_url = coverImagePath;
                webStory.slug = dto.slug; // update slug in mapped object if needed

                // Create WebStoryPage list
                var imagePages = new List<WebStoryPage>();
                int pairCount = Math.Max(dto.images?.Count ?? 0, dto.text_content?.Count ?? 0);

                for (int i = 0; i < pairCount; i++)
                {
                    string? imagePath = null;
                    string? text = null;

                    if (i < (dto.images?.Count ?? 0) && dto.images[i] != null && dto.images[i].Length > 0)
                    {
                        imagePath = await FileUpload.SaveFileAsync(dto.images[i], "upload");
                    }

                    if (i < (dto.text_content?.Count ?? 0))
                    {
                        text = dto.text_content[i];
                    }

                    if (!string.IsNullOrWhiteSpace(imagePath) || !string.IsNullOrWhiteSpace(text))
                    {
                        imagePages.Add(new WebStoryPage
                        {
                            image_url = imagePath,
                            text_content = text
                        });
                    }
                }

                // Link the pages to the story
                webStory.Pages = imagePages;

                // Save to database
                var savedWebStory = await unitofWork.WebStoryRepository.CreateAsync(webStory);
                if (savedWebStory == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Web story creation failed" });

                await unitofWork.Save();
                return Ok(new { message = "Web story created successfully", data = mapper.Map<WebStoryDto>(savedWebStory)});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Something went wrong",
                    error = ex.Message
                });
            }
        }


        /// <summary>
        ///  PUT: api/Category
        /// </summary>

        [HttpPut("UpdateWebStory/{id}")]
        public async Task<IActionResult> UpdateWebStory([FromForm] WebStoryUpdateDto dto, int id)
        {
            if (id == 0) return BadRequest(new { message = "Invalid Web Story ID" });

            try
            {
                // Corrected: Pass dto instead of undefined updatedStory
                var result = await unitofWork.WebStoryRepository.UpdateWebStoryAsync(id, dto);

                if (result == null) return NotFound(new { message = "Web Story not found or update failed" });

                return Ok(new { message = "Web Story updated successfully", data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An error occurred while updating the Web Story",
                    error = ex.Message
                });
            }
        }

    }
}

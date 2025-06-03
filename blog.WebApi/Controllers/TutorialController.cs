using AutoMapper;
using blog.Core.DTOs.TutorialDtos;
using blog.Core.Entities;
using blog.Core.Helpers;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TutorialController : Controller
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public TutorialController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        /// <summary>
        ///  GET All: api/Tutorial
        /// </summary>

        [HttpGet("GetAllTutorial")]
        public async Task<IActionResult> GetAllTutorial()
        {
            var modalTutorial = await unitofWork.TutorialRepository.GetAllAsync(includeProperties: "galleries,tags,TutorialDetails");

            var tutorialDtos = mapper.Map<List<TutorialDto>>(modalTutorial);
            return Ok(tutorialDtos);
        }



        /// <summary>
        ///  GET By Id: api/Tutorial Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetTutorial/{id}")]
        public async Task<IActionResult> GetTutorial(int id)
        {
            try
            {
                var ModalTutorial = await unitofWork.TutorialRepository.GetAsync(x => x.tutorial_id == id, includeProperties: "galleries,tags,TutorialDetails");
                if (ModalTutorial == null)
                {
                    return NotFound("Tutorial not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var TutorialDto = mapper.Map<TutorialDto>(ModalTutorial);
                return Ok(TutorialDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        [HttpGet("GetTutorialBySlug/{slug}")]
        public async Task<IActionResult> GetTutorialBySlug(string? slug)
        {
            try
            {
                var ModalTutorial = await unitofWork.TutorialRepository.GetAsync(x => x.tutorial_slug == slug, includeProperties: "galleries,tags,TutorialDetails");
                if (ModalTutorial == null)
                {
                    return NotFound("Tutorial not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var TutorialDto = mapper.Map<TutorialDto>(ModalTutorial);
                return Ok(TutorialDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Tutorial
        /// </summary>

        [HttpDelete("DeleteByIdTutorial/{id}")]
        public async Task<IActionResult> DeleteByIdTutorial([FromRoute] int id)
        {
            try
            {
                // Fetch data using the repository
                var ModalTutorial = await unitofWork.TutorialRepository.GetAsync(x => x.tutorial_id == id);
                // Check if the data exists
                if (ModalTutorial == null)
                {
                    return NotFound("Tutorial not found");
                }
                // Delete the business profile
                await unitofWork.TutorialRepository.DeleteAsync(ModalTutorial);
                await unitofWork.Save();
                //return Ok("Tutorial deleted successfully");
                return Ok(new { message = "Tutorial deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }

        }


        /// <summary>
        ///  Deleted All Tutorial
        /// </summary>

        [HttpDelete("DeleteAllTutorial")]
        public async Task<IActionResult> DeleteAllTutorial()
        {
            try
            {
                // Fetch all Tutorial from the database
                var modalTutorial = await unitofWork.TutorialRepository.GetAllAsync();

                if (modalTutorial == null || !modalTutorial.Any())
                {
                    return NotFound("No Tutorial found to delete.");
                }

                // Call the repository method to delete the range of Tutorial
                await unitofWork.TutorialRepository.DeleteRangeAsync(modalTutorial);
                await unitofWork.Save();
                // Save changes to the database
                return Ok(new { message = "Tutorial updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework as applicable)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  Tutorial: api/Tutorial
        /// </summary>


        [HttpPost("CreateTutorial")]
        public async Task<IActionResult> CreateTutorial([FromForm] TutorialAddDto obj)
        {
            try
            {

                var model = mapper.Map<Tutorial>(obj);

                // Generate unique slug
                if (string.IsNullOrWhiteSpace(obj.tutorial_slug) && string.IsNullOrWhiteSpace(obj.tutorial_title))
                    throw new ArgumentException("Tutorial title or slug must be provided.");

                string baseText = !string.IsNullOrWhiteSpace(obj.tutorial_slug) ? obj.tutorial_slug! : obj.tutorial_title!;

                obj.tutorial_slug = await SlugGenerator.GenerateUniqueSlugAsync(baseText, async (baseSlug) =>
                {
                    var matches = await unitofWork.TutorialRepository.GetAllAsync(x => x.tutorial_slug.StartsWith(baseSlug));
                    return matches.Select(x => x.tutorial_slug).ToList();
                });

                // Save main image
                if (obj.tutorial_image != null && obj.tutorial_image.Length > 0)
                {
                    model.tutorial_image = await FileUpload.SaveFileAsync(obj.tutorial_image, "upload");
                }

                // Save galleries
                if (obj.galleries.Any())
                {
                    model.galleries = new List<Gallery>();
                    foreach (var galleryFile in obj.galleries)
                    {
                        if (galleryFile?.Length > 0)
                        {
                            var galleryPath = await FileUpload.SaveFileAsync(galleryFile, Path.Combine("upload"));
                            model.galleries.Add(new Gallery { gallery_img = galleryPath });
                        }
                    }
                }

            
                // Save tutorial descriptions + languages
                if (obj.tutorial_descriptions.Any() && obj.languages.Any())
                {
                    model.TutorialDetails = obj.tutorial_descriptions.Select((desc, index) => new Tutorial_Details
                        { 
                        tutorial_description = desc, languages = obj.languages.ElementAtOrDefault(index) ?? "" 
                    }).ToList();
                }

                // Tags Names
                if (obj.tag_name.Any())
                {
                    model.tags = obj.tag_name.Select(desc => new Tags { tag_name = desc }).ToList();
                }

              
                var newTutorial = await unitofWork.TutorialRepository.CreateAsync(model);
                if (newTutorial == null) return StatusCode(500, "Failed to create tutorial");

                await unitofWork.Save();

                var tutorialDto = mapper.Map<TutorialDto>(newTutorial);
                return Ok(tutorialDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        /// <summary>
        ///  PUT: api/Tutorial
        /// </summary>
        
        [HttpPut("UpdateTutorial/{id}")]
        public async Task<IActionResult> UpdateTutorial([FromForm] TutorialUpdateDto obj, int id)
        {
            try
            {
                var existingTutorial = await unitofWork.TutorialRepository.GetAsync(x => x.tutorial_id == id);

                if (existingTutorial == null) return NotFound("Tutorial not found");

                // Generate unique slug 
                string baseText = string.IsNullOrWhiteSpace(obj.tutorial_slug) ? obj.tutorial_title : obj.tutorial_slug;
                obj.tutorial_slug = await SlugGenerator.GenerateUniqueSlugAsync(baseText, async (baseSlug) =>
                {
                    var matches = await unitofWork.TutorialRepository.GetAllAsync(x => x.tutorial_slug.StartsWith(baseSlug));
                    return matches.Select(x => x.tutorial_slug).ToList();
                });


                // Handle tutorial image
                if (obj.tutorial_image != null)
                {
                    obj.tutorial_image_path = await FileUpload.SaveFileAsync(obj.tutorial_image, "upload");
                }

                // Handle galleries
                if (obj.galleries?.Any() == true)
                {
                    obj.galleries_paths = new List<string>();
                    foreach (var file in obj.galleries)
                    {
                        var path = await FileUpload.SaveFileAsync(file, "upload");
                        obj.galleries_paths.Add(path);
                    }
                }

                // Perform update
                var updatedTutorial = await unitofWork.TutorialRepository.UpdateTutorialAsync(id, obj);
                await unitofWork.Save();

                return Ok(new { message = "Tutorial updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

using AutoMapper;
using blog.Core.DTOs.TagsDtos;
using blog.Core.Entities;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public TagsController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        /// <summary>
        ///  GET All: api/Tags
        /// </summary>

        [HttpGet("GetAllTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var modalTags = await unitofWork.TagsRepository.GetAllAsync();
            return Ok(mapper.Map<List<TagsDto>>(modalTags));
        }

        /// <summary>
        ///  GET By Id: api/Tags Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetTags/{id}")]
        public async Task<IActionResult> GetTags(int id)
        {
            try
            {
                var ModalTags = await unitofWork.TagsRepository.GetAsync(x => x.tag_id == id);
                if (ModalTags == null)
                {
                    return NotFound("Tags not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var TagsDto = mapper.Map<TagsDto>(ModalTags);
                return Ok(TagsDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Tags
        /// </summary>

        [HttpDelete("DeleteByIdTags/{id}")]
        public async Task<IActionResult> DeleteByIdTags([FromRoute] int id)
        {
            try
            {
                // Fetch data using the repository
                var ModalTags = await unitofWork.TagsRepository.GetAsync(x => x.tag_id == id);
                // Check if the data exists
                if (ModalTags == null)
                {
                    return NotFound("Tags not found");
                }
                // Delete the business profile
                await unitofWork.TagsRepository.DeleteAsync(ModalTags);
                await unitofWork.Save();
                //return Ok("Tags deleted successfully");
                return Ok(new { message = "Tag deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }

        }


        /// <summary>
        ///  Deleted All Tags
        /// </summary>

        [HttpDelete("DeleteAllTags")]
        public async Task<IActionResult> DeleteAllTags()
        {
            try
            {
                // Fetch all Tags from the database
                var modalTags = await unitofWork.TagsRepository.GetAllAsync();

                if (modalTags == null || !modalTags.Any())
                {
                    return NotFound("No Tags found to delete.");
                }

                // Call the repository method to delete the range of Tags
                await unitofWork.TagsRepository.DeleteRangeAsync(modalTags);
                await unitofWork.Save();
                // Save changes to the database
                return Ok(new { message = "All Tags Deleted successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework as applicable)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  Tags: api/Tags
        /// </summary>
        [HttpPost("CreateTags")]
        public async Task<IActionResult> CreateTags([FromForm] TagsAddDto obj)
        {
            try
            {
                var model = mapper.Map<Tags>(obj);
                var ModalTagsNew = await unitofWork.TagsRepository.CreateAsync(model);

                if (ModalTagsNew == null)
                {
                    return BadRequest("something want wrong");
                }
                await unitofWork.Save();
                var productesValueDto = mapper.Map<TagsDto>(ModalTagsNew);
                return Ok(productesValueDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("something wrong", ex);
            }
        }

        /// <summary>
        ///  PUT: api/Tags
        /// </summary>

        [HttpPut("UpdateTags/{id}")]
        public async Task<IActionResult> UpdateTags([FromForm] TagsUpdateDto obj, int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError(id.ToString(), "Id cannot be 0 or null");
                }

                var model = mapper.Map<Tags>(obj);
                var updatedTags = await unitofWork.TagsRepository.UpdateTagsAsync(id, model);

                if (updatedTags == null)
                {
                    return NotFound("Tags not found");
                }
                return Ok(new { message = "Tags updated successfully" });
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }
    }
}

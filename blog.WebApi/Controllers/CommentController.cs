using AutoMapper;
using blog.Core.DTOs.CommentDtos;
using blog.Core.Entities;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CommentController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public CommentController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        /// <summary>
        ///  GET All: api/Comment
        /// </summary>

        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAllComment()
        {
            var modalComment = await unitofWork.CommentRepository.GetAllAsync();
            return Ok(mapper.Map<List<CommentDto>>(modalComment));
        }

        /// <summary>
        ///  GET By Id: api/Comment Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetComment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            try
            {
                var ModalComment = await unitofWork.CommentRepository.GetAsync(x => x.comment_id == id);
                if (ModalComment == null)
                {
                    return NotFound("Comment not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var CommentDto = mapper.Map<CommentDto>(ModalComment);
                return Ok(CommentDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Comment
        /// </summary>

        [HttpDelete("DeleteByIdComment/{id}")]
        public async Task<IActionResult> DeleteByIdComment([FromRoute] int id)
        {
            try
            {
                // Fetch data using the repository
                var ModalComment = await unitofWork.CommentRepository.GetAsync(x => x.comment_id == id);
                // Check if the data exists
                if (ModalComment == null)
                {
                    return NotFound("Comment not found");
                }
                // Delete the business profile
                await unitofWork.CommentRepository.DeleteAsync(ModalComment);
                await unitofWork.Save();
                //return Ok("Comment deleted successfully");
                return Ok(new { message = "Comment deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }

        }


        /// <summary>
        ///  Deleted All Comment
        /// </summary>

        [HttpDelete("DeleteAllComment")]
        public async Task<IActionResult> DeleteAllComment()
        {
            try
            {
                // Fetch all Comment from the database
                var modalComment = await unitofWork.CommentRepository.GetAllAsync();

                if (modalComment == null || !modalComment.Any())
                {
                    return NotFound("No Comment found to delete.");
                }

                // Call the repository method to delete the range of Comment
                await unitofWork.CommentRepository.DeleteRangeAsync(modalComment);
                await unitofWork.Save();
                // Save changes to the database
                return Ok(new { message = "Comment updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework as applicable)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  Comment: api/Comment
        /// </summary>
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment([FromForm] CommentAddDto obj)
        {
            try
            {
              
                var model = mapper.Map<Comment>(obj);
                var ModalCommentNew = await unitofWork.CommentRepository.CreateAsync(model);

                if (ModalCommentNew == null)
                {
                    return BadRequest("Failed to create business profile");
                }
                await unitofWork.Save();
                var productesValueDto = mapper.Map<CommentAddDto>(ModalCommentNew);
                return Ok(productesValueDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("something wrong", ex);
            }
        }

        /// <summary>
        ///  PUT: api/Comment
        /// </summary>

        [HttpPut("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment([FromForm] CommentUpdateDto obj, int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError(id.ToString(), "Id cannot be 0 or null");
                }

                var model = mapper.Map<Comment>(obj);
                var updatedComment = await unitofWork.CommentRepository.UpdateCommentAsync(id, model);

                if (updatedComment == null)
                {
                    return NotFound("Comment not found");
                }
                return Ok(new { message = "Comment updated successfully" });
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }
    
    }
}

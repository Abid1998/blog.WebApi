using AutoMapper;
using blog.Core.DTOs.CategoriesDtos;
using blog.Core.Entities;
using blog.Core.Helpers;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public CategoriesController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        /// <summary>
        ///  GET All: api/Category
        /// </summary>

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var modalCategory = await unitofWork.CategoriesRepository.GetAllAsync();
            return Ok(mapper.Map<List<CategoryDto>>(modalCategory));
        }

        /// <summary>
        ///  GET By Id: api/Category Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var ModalCategory = await unitofWork.CategoriesRepository.GetAsync(x => x.category_id == id);
                if (ModalCategory == null)
                {
                    return NotFound("Category not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var CategoryDto = mapper.Map<CategoryDto>(ModalCategory);
                return Ok(CategoryDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        [HttpGet("GetCategoryBySlug/{slug}")]
        public async Task<IActionResult> GetCategoryBySlug(string? slug)
        {
            try
            {
                var ModalCategory = await unitofWork.CategoriesRepository.GetAsync(x => x.category_slug == slug);
                if (ModalCategory == null)
                {
                    return NotFound("Category not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var CategoryDto = mapper.Map<CategoryDto>(ModalCategory);
                return Ok(CategoryDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Category
        /// </summary>

        [HttpDelete("DeleteByIdCategory/{id}")]
        public async Task<IActionResult> DeleteByIdCategory([FromRoute] int id)
        {
            try
            {
                // Fetch data using the repository
                var ModalCategory = await unitofWork.CategoriesRepository.GetAsync(x => x.category_id == id);
                // Check if the data exists
                if (ModalCategory == null)
                {
                    return NotFound("Category not found");
                }
                // Delete the business profile
                await unitofWork.CategoriesRepository.DeleteAsync(ModalCategory);
                await unitofWork.Save();
                //return Ok("Category deleted successfully");
                return Ok(new { message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }

        }

     
        /// <summary>
        ///  Deleted All Category
        /// </summary>
 
        [HttpDelete("DeleteAllCategory")]
        public async Task<IActionResult> DeleteAllCategory()
        {
            try
            {
                // Fetch all categories from the database
                var modalCategory = await unitofWork.CategoriesRepository.GetAllAsync();

                if (modalCategory == null || !modalCategory.Any())
                {
                    return NotFound("No categories found to delete.");
                }

                // Call the repository method to delete the range of categories
                await unitofWork.CategoriesRepository.DeleteRangeAsync(modalCategory);
                await unitofWork.Save();
                // Save changes to the database
                return Ok(new { message = "Category updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework as applicable)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  POST: api/Category
        /// </summary>
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryAddDto obj)
        {
            try
            {
                // Generate unique slug
                string? baseText = string.IsNullOrWhiteSpace(obj.category_slug) ? obj.category_name?? "" : obj.category_slug;
                obj.category_slug = await SlugGenerator.GenerateUniqueSlugAsync(baseText, async (baseSlug) =>
                {
                    var existingSlugs = await unitofWork.CategoriesRepository.GetAllAsync(x => (x.category_slug?? string.Empty).StartsWith(baseSlug));
                    return existingSlugs.Select(x => x.category_slug ?? string.Empty).ToList();
                });

                var ModalCategory = await unitofWork.CategoriesRepository.GetAsync(x => x.category_slug == obj.category_slug);
                var model = mapper.Map<Categories>(obj);
               
                if (obj.category_image != null && obj.category_image.Length > 0)
                {
                    model.category_image = await FileUpload.SaveFileAsync(obj.category_image, "upload");
                }


                var ModalCategoryNew = await unitofWork.CategoriesRepository.CreateAsync(model);

                if (ModalCategoryNew == null)
                {
                    return BadRequest("Failed to create business profile");
                }
                await unitofWork.Save();
                var categoryAddDto = mapper.Map<CategoryDto>(ModalCategoryNew);
                return Ok(categoryAddDto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("something wrong", ex);
            }
        }

        /// <summary>
        ///  PUT: api/Category
        /// </summary>
 
        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromForm] CategoryUpdateDto obj, int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError(id.ToString(), "Id cannot be 0 or null");
                }

                string? baseText = string.IsNullOrWhiteSpace(obj.category_slug) ? obj.category_name ?? "" : obj.category_slug;
                obj.category_slug = await SlugGenerator.GenerateUniqueSlugAsync(baseText, async (baseSlug) =>
                {
                    var existingSlugs = await unitofWork.CategoriesRepository.GetAllAsync(x => (x.category_slug ?? string.Empty).StartsWith(baseSlug));
                    return existingSlugs.Select(x => x.category_slug ?? string.Empty).ToList();
                });

                var model = mapper.Map<Categories>(obj);

                if (obj.category_image != null && obj.category_image.Length > 0)
                {
                    model.category_image = await FileUpload.SaveFileAsync(obj.category_image, "upload");
                }

                var updatedCategory = await unitofWork.CategoriesRepository.UpdateCategoriesAsync(id, model);
                if (updatedCategory == null)
                {
                    return NotFound("Category not found");
                }
                return Ok(new { message = "Category updated successfully" });
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }



    }
}

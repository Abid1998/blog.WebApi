using AutoMapper;
using blog.Core.DTOs.GalleryDtos;
using blog.Core.Entities;
using blog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {

        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public GalleryController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        /// <summary>
        ///  GET All: api/Gallery
        /// </summary>

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var modalGallery = await unitofWork.GalleryRepository.GetAllAsync();
            return Ok(mapper.Map<List<GalleryDto>>(modalGallery));
        }

        /// <summary>
        ///  GET By Id: api/Gallery Id Wise And Slug Wise
        /// </summary>

        [HttpGet("GetGallery/{id}")]
        public async Task<IActionResult> GetGallery(int id)
        {
            try
            {
                var ModalGallery = await unitofWork.GalleryRepository.GetAsync(x => x.gallery_id == id);
                if (ModalGallery == null)
                {
                    return NotFound("Gallery not found");
                }
                // Map DBO to Domain and return the data with HTTP 200 status
                var GalleryDto = mapper.Map<GalleryDto>(ModalGallery);
                return Ok(GalleryDto);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }


        /// <summary>
        ///  Delete BY Id: api/Gallery
        /// </summary>

        [HttpDelete("DeleteByIdGallery/{id}")]
        public async Task<IActionResult> DeleteByIdGallery([FromRoute] int id)
        {
            try
            {
                // Fetch data using the repository
                var ModalGallery = await unitofWork.GalleryRepository.GetAsync(x => x.gallery_id == id);
                // Check if the data exists
                if (ModalGallery == null)
                {
                    return NotFound("Gallery not found");
                }
                // Delete the business profile
                await unitofWork.GalleryRepository.DeleteAsync(ModalGallery);
                await unitofWork.Save();
                //return Ok("Gallery deleted successfully");
                return Ok(new { message = "Gallery deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Something Wrong", ex);
            }

        }


        /// <summary>
        ///  Deleted All Gallery
        /// </summary>

        [HttpDelete("DeleteAllGallery")]
        public async Task<IActionResult> DeleteAllGallery()
        {
            try
            {
                // Fetch all Gallery from the database
                var modalGallery = await unitofWork.GalleryRepository.GetAllAsync();

                if (modalGallery == null || !modalGallery.Any())
                {
                    return NotFound("No Gallery found to delete.");
                }

                // Call the repository method to delete the range of Gallery
                await unitofWork.GalleryRepository.DeleteRangeAsync(modalGallery);
                await unitofWork.Save();
                // Save changes to the database
                return Ok(new { message = "Gallery updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework as applicable)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        ///  Gallery: api/Gallery
        /// </summary>
     
     

//        using CG.Web.MegaApiClient;

//[HttpPost("CreateGallery")]
//    public async Task<IActionResult> CreateGallery([FromForm] GalleryAddDto obj)
//    {
//        try
//        {
//            var existingPost = await unitofWork.PostRepository.GetAsync(x => x.post_id == obj.post_id);
//            if (existingPost == null)
//            {
//                return BadRequest($"Post with ID {obj.post_id} does not exist.");
//            }

//            var model = mapper.Map<Gallery>(obj);

//            if (obj.gallery_img != null)
//            {
//                // Save file temporarily
//                var tempFilePath = Path.GetTempFileName();
//                using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
//                {
//                    await obj.gallery_img.CopyToAsync(fileStream);
//                }

//                // Login to MEGA
//                var client = new MegaApiClient();
//                client.Login("your-mega-email@example.com", "yourPassword"); // Use environment vars in production

//                // Get Root folder (or find custom folder)
//                var nodes = client.GetNodes();
//                var uploadFolder = nodes.FirstOrDefault(n => n.Type == NodeType.Root); // Or: .First(n => n.Name == "Gallery")

//                if (uploadFolder == null)
//                    throw new Exception("Could not find upload folder on MEGA.");

//                // Upload file
//                var uploadedNode = client.UploadFile(tempFilePath, uploadFolder);

//                // Get public link
//                var fileLink = client.GetDownloadLink(uploadedNode);
//                model.gallery_img = fileLink.ToString(); // Store MEGA file URL

//                // Logout and clean temp file
//                client.Logout();
//                System.IO.File.Delete(tempFilePath);
//            }

//            // Save to DB
//            var newGallery = await unitofWork.GalleryRepository.CreateAsync(model);
//            await unitofWork.Save();

//            var galleryNewDto = mapper.Map<GalleryDto>(newGallery);
//            return Ok(galleryNewDto);
//        }
//        catch (Exception ex)
//        {
//            return StatusCode(500, new
//            {
//                message = "An error occurred while creating the gallery.",
//                error = ex.Message,
//                innerException = ex.InnerException?.Message
//            });
//        }
//    }









    //[HttpPost("CreateGallery")]
    //public async Task<IActionResult> CreateGallery([FromForm] GalleryAddDto obj)
    //{
    //    try
    //    {

    //        var model = mapper.Map<Gallery>(obj);

    //        if (obj.gallery_img != null)
    //        {
    //            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");
    //            if (!Directory.Exists(uploadDirectory))
    //            {
    //                Directory.CreateDirectory(uploadDirectory);
    //            }

    //            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.gallery_img.FileName);
    //            var filePath = Path.Combine(uploadDirectory, fileName);

    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await obj.gallery_img.CopyToAsync(stream);
    //            }

    //            model.gallery_img = Path.Combine("upload", fileName).Replace("\\", "/");
    //        }

    //        var ModalGalleryNew = await unitofWork.GalleryRepository.CreateAsync(model);



    //        await unitofWork.Save();
    //        var GalleryDto = mapper.Map<GalleryDto>(ModalGalleryNew);
    //        return Ok(GalleryDto);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new InvalidOperationException("something wrong", ex);
    //    }
    //}


    //[HttpPost("CreateGallery")]
    //public async Task<IActionResult> CreateGallery([FromForm] GalleryAddDto obj)
    //{
    //    try
    //    {
    //        var existingPost = await unitofWork.PostRepository.GetAsync(x => x.post_id == obj.post_id);
    //        if (existingPost == null)
    //        {
    //            return BadRequest($"Post with ID {obj.post_id} does not exist.");
    //        }

    //        var model = mapper.Map<Gallery>(obj);

    //        if (obj.gallery_img != null)
    //        {
    //            using (var httpClient = new HttpClient())
    //            {
    //                using (var content = new MultipartFormDataContent())
    //                {
    //                    var streamContent = new StreamContent(obj.gallery_img.OpenReadStream());
    //                    streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(obj.gallery_img.ContentType);

    //                    // Use correct key name expected by API
    //                    content.Add(streamContent, "file", obj.gallery_img.FileName);

    //                    var response = await httpClient.PostAsync("https://mega.nz/folder/2JQCFC5Y#dyWS92Q77FUxw_rF8vZiag", content);

    //                    if (response.IsSuccessStatusCode)
    //                    {
    //                        var result = await response.Content.ReadAsStringAsync();
    //                        var jsonResult = JsonConvert.DeserializeObject<JObject>(result);

    //                        // Use actual key returned by API
    //                        model.gallery_img = jsonResult["imageUrl"]?.ToString(); // or adjust as needed
    //                    }
    //                    else
    //                    {
    //                        var errorText = await response.Content.ReadAsStringAsync();
    //                        throw new Exception($"Image upload failed: {response.StatusCode} - {errorText}");
    //                    }
    //                }
    //            }
    //        }

    //        // 💾 Save to database
    //        var newGallery = await unitofWork.GalleryRepository.CreateAsync(model);
    //        await unitofWork.Save();

    //        // 🔁 Map entity back to DTO and return
    //        var galleryNewDto = mapper.Map<GalleryDto>(newGallery);
    //        return Ok(galleryNewDto);
    //    }
    //    catch (Exception ex)
    //    {
    //        // ⚠️ Return clear error response for debugging
    //        return StatusCode(500, new
    //        {
    //            message = "An error occurred while creating the gallery.",
    //            error = ex.Message,
    //            innerException = ex.InnerException?.Message
    //        });
    //    }
    //}














    //if (obj.gallery_img != null)
    //{
    //    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");
    //    if (!Directory.Exists(uploadDirectory))
    //    {
    //        Directory.CreateDirectory(uploadDirectory);
    //    }

    //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(obj.gallery_img.FileName)}";
    //    var filePath = Path.Combine(uploadDirectory, fileName);

    //    using (var stream = new FileStream(filePath, FileMode.Create))
    //    {
    //        await obj.gallery_img.CopyToAsync(stream);
    //    }

    //    model.gallery_img = Path.Combine("upload", fileName).Replace("\\", "/");
    //}


    /// <summary>
    ///  PUT: api/Gallery
    /// </summary>

    [HttpPut("UpdateGallery/{id}")]
        public async Task<IActionResult> UpdateGallery([FromForm] GalleryUpdateDto obj, int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError(id.ToString(), "Id cannot be 0 or null");
                }

                var model = mapper.Map<Gallery>(obj);

                if (obj.gallery_img != null)
                {
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.gallery_img.FileName);
                    var filePath = Path.Combine(uploadDirectory, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await obj.gallery_img.CopyToAsync(stream);
                    }

                    model.gallery_img = Path.Combine("upload", fileName).Replace("\\", "/");
                }

                var updatedGallery = await unitofWork.GalleryRepository.UpdateGalleryAsync(id, model);

                if (updatedGallery == null)
                {
                    return NotFound("Gallery not found");
                }
                return Ok(new { message = "Gallery updated successfully" });
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Something Wrong", ex);
            }
        }
    
    }

}

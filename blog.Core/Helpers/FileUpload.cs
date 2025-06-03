using Microsoft.AspNetCore.Http;


namespace blog.Core.Helpers
{
    public static class FileUpload
    {
        public static async Task<string> SaveFileAsync(IFormFile file, string subDirectory)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subDirectory);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return Path.Combine(subDirectory, fileName).Replace("\\", "/");
        }
    }
}

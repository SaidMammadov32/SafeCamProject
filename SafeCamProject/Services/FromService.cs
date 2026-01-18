using SafeCamProject.Services.Interfaces;

namespace SafeCamProject.Services
{
    public class FromService : IFromService
    {
        private readonly IWebHostEnvironment _env;

        public FromService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string GeneratePath(string folder, string filename)
        {
            return Path.Combine(_env.WebRootPath, folder, filename);
        }

        public string GenerateUniqueFileName(string filename)
        {
            return Guid.NewGuid().ToString() + "_" + filename;
        }

        public async Task UploadAsync(IFormFile file, string path)
        {
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
    }
}

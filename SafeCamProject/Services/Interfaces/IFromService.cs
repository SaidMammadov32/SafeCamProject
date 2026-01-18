namespace SafeCamProject.Services.Interfaces
{
    public interface IFromService
    {
        string GenerateUniqueFileName(string filename);
        string GeneratePath(string folder, string filename);
        Task UploadAsync(IFormFile file, string path);
        void Delete(string path);
    }
}

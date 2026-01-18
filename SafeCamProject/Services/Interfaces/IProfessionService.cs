using Microsoft.AspNetCore.Mvc.Rendering;
using SafeCamProject.ViewsModel.Profession;

namespace SafeCamProject.Services.Interfaces
{
    public interface IProfessionService
    {
        public Task<IEnumerable<ProfessionUIVM>> GetAllAsync();
        public Task<IEnumerable<ProfessionVM>> GetAllAdminAsync();

        public Task<ProfessionDetailVM?> GetByIdAsync(int id);

        Task CreateAsync(ProfessionCreateVM professionCreateVM);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ProfessionUpdateVM updateVM);

        Task<SelectList> GetAllSelectedAsync();
    }
}

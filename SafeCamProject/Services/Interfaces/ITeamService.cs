using SafeCamProject.ViewsModel.Profession;
using SafeCamProject.ViewsModel.Team;

namespace SafeCamProject.Services.Interfaces
{
    public interface ITeamService
    {
        public Task<IEnumerable<TeamUIVM>> GetAllAsync();
        public Task<IEnumerable<TeamVM>> GetAllAdminAsync();
        public Task<TeamDetailVM> GetByIdAsync(int id);

        Task CreateAsync(TeamCreateVM teamCreateVM);
        Task DeleteASync(int id);
        Task UpdateAsync(int id, TeamUpdateVM teamUpdateVM);
    }
}

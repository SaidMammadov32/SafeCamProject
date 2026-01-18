using Microsoft.EntityFrameworkCore;
using SafeCamProject.Data;
using SafeCamProject.Models;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Team;

namespace SafeCamProject.Services
{
    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFromService _fromservice;
        public TeamService(ApplicationDbContext context, IFromService fromservice)
        {
            _context = context;
            _fromservice = fromservice;
        }

        public async Task CreateAsync(TeamCreateVM teamCreateVM)
        {
            var filename = _fromservice.GenerateUniqueFileName(teamCreateVM.Image.FileName);
            var path = _fromservice.GeneratePath("assets/img", filename);
            await _fromservice.UploadAsync(teamCreateVM.Image, path);
            var team = new Team
            {
                Name = teamCreateVM.Name,
                Image = filename,
                ProfessionId = teamCreateVM.ProfessionId

            };
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteASync(int id)
        {
            var data = await _context.Teams.FindAsync(id);
            var oldPath = _fromservice.GeneratePath("assets/img", data.Image);
            _fromservice.Delete(oldPath);

            _context.Teams.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeamVM>> GetAllAdminAsync()
        {
            var teams = await _context.Teams.Include(p => p.Profession).Select(t => new TeamVM
            {
                Id = t.Id,
                Name = t.Name,
                Image = t.Image,
                CreateDate = t.CreatedDate,
                Profession = t.Profession.Name
            }).ToListAsync();
            return teams;
        }

        public async Task<IEnumerable<TeamUIVM>> GetAllAsync()
        {
            var teams = await _context.Teams.Include(p=>p.Profession).Select(t => new TeamUIVM
            {
                Id = t.Id,
                Name = t.Name,
                Image = t.Image,
                Profession = t.Profession.Name
            }).ToListAsync();
            return teams;
        }

        public async Task<TeamDetailVM> GetByIdAsync(int id)
        {
            var team = await _context.Teams.Include(p=>p.Profession).FirstOrDefaultAsync(t=>t.Id==id);
            return new TeamDetailVM
            {
                Id = team.Id,
                Name = team.Name,
                Image = team.Image,
                CreateDate = team.CreatedDate,
                Profession = team.Profession.Name,
                ProfessionId = team.Profession.Id
            };
        }

        public async Task UpdateAsync(int id, TeamUpdateVM teamUpdateVM)
        {
            var data = await _context.Teams.FindAsync(id);
            var oldPath = _fromservice.GeneratePath("assets/img", data.Image);
            _fromservice.Delete(oldPath);


            var filename = _fromservice.GenerateUniqueFileName(teamUpdateVM.Image.FileName);
            var path = _fromservice.GeneratePath("assets/img", filename);
            await _fromservice.UploadAsync(teamUpdateVM.Image, path);


            teamUpdateVM.Name = data.Name;
            teamUpdateVM.ProfessionId = data.ProfessionId;
            data.Image = filename;

            await _context.SaveChangesAsync();

        }
    }
}

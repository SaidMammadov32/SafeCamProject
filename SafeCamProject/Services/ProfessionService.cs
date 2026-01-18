using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafeCamProject.Data;
using SafeCamProject.Models;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Profession;

namespace SafeCamProject.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly ApplicationDbContext _context;
        public ProfessionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(ProfessionCreateVM professionCreateVM)
        {
            var profession = new Profession
            {
                Name = professionCreateVM.Name,
                CreatedDate = DateTime.Now
            };
            await _context.Professions.AddAsync(profession);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Professions.FindAsync(id);
            _context.Professions.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProfessionVM>> GetAllAdminAsync()
        {
            var profession = await _context.Professions.Select(p => new ProfessionVM
            {
                Id = p.Id,
                Name = p.Name,
                CreateDate = p.CreatedDate
            }).ToListAsync();

            return profession;
        }

        public async Task<IEnumerable<ProfessionUIVM>> GetAllAsync()
        {
            var professions = await _context.Professions.Select(p => new ProfessionUIVM
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();

            return professions;
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var datas = await _context.Professions.ToListAsync();
            return new SelectList(datas, "Id", "Name");
        }

        public async Task<ProfessionDetailVM?> GetByIdAsync(int id)
        {
            var profession = await _context.Professions.FindAsync(id);

            return new ProfessionDetailVM
            {
                Id = profession.Id,
                Name = profession.Name,
                CreateDate = profession.CreatedDate
            };
        }

        public async Task UpdateAsync(int id, ProfessionUpdateVM updateVM)
        {
            var data = await _context.Professions.FindAsync(id);
            data.Name = updateVM.Name;
            await _context.SaveChangesAsync();
        }
    }
}

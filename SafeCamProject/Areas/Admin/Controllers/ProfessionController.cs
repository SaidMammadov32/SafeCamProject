using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Profession;

namespace SafeCamProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfessionController : Controller
    {
        private readonly IProfessionService _professionService;
        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }
        public async Task<IActionResult> Index()
        {
            var professions = await _professionService.GetAllAdminAsync();
            return View(professions);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null) return BadRequest();
            var profession = await _professionService.GetByIdAsync(id);
            if (profession == null) return NotFound();
            return View(profession);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessionCreateVM professionCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _professionService.CreateAsync(professionCreateVM);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _professionService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            await _professionService.DeleteAsync(data.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _professionService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            return View(new ProfessionUpdateVM
            {
                Id = data.Id,
                Name = data.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProfessionUpdateVM professionUpdateVM)
        {
            if(!ModelState.IsValid) return BadRequest();
            if (id == null) return BadRequest();
            var data = await _professionService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            await _professionService.UpdateAsync(data.Id, professionUpdateVM);
            return RedirectToAction("Index");
        }
    }
}

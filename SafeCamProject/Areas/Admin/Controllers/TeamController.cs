using Microsoft.AspNetCore.Mvc;
using SafeCamProject.Services;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel.Profession;
using SafeCamProject.ViewsModel.Team;

namespace SafeCamProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IProfessionService _professionService;
        public TeamController(ITeamService teamService, IProfessionService professionService)
        {
            _teamService = teamService;
            _professionService = professionService;
        }
        public async Task<IActionResult> Index()
        {
            var teams = await _teamService.GetAllAdminAsync();
            return View(teams);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null) return BadRequest();
            var team = await _teamService.GetByIdAsync(id);
            if (team == null) return NotFound();
            return View(team);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Professions = await _professionService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamCreateVM teamCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Professions = await _professionService.GetAllSelectedAsync();
                return View(teamCreateVM);
            }
            await _teamService.CreateAsync(teamCreateVM);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _teamService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            await _teamService.DeleteASync(data.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _teamService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            ViewBag.Professions = await _professionService.GetAllSelectedAsync();

            return View(new TeamUpdateVM
            {
                Id = data.Id,
                Name = data.Name,
                ProfessionId = data.ProfessionId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, TeamUpdateVM teamUpdateVM)
        {
            if (id == null) return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Professions = await _professionService.GetAllSelectedAsync();
                return View(teamUpdateVM);
            }

            var data = await _teamService.GetByIdAsync(id.Value);
            if (data == null) return NotFound();

            await _teamService.UpdateAsync(data.Id, teamUpdateVM);
            return RedirectToAction("Index");
        }
    }
}

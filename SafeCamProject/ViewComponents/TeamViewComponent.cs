using Microsoft.AspNetCore.Mvc;
using SafeCamProject.Services.Interfaces;
using SafeCamProject.ViewsModel;

namespace SafeCamProject.ViewComponents
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly IProfessionService _professionService;
        private readonly ITeamService _teamService;
        public TeamViewComponent(IProfessionService professionService , ITeamService teamService)
        {
            _professionService = professionService;
            _teamService = teamService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teams = await _teamService.GetAllAsync();
            
            return View(teams);
        }
    }
}
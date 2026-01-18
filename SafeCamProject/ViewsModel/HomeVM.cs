using SafeCamProject.ViewsModel.Profession;
using SafeCamProject.ViewsModel.Team;

namespace SafeCamProject.ViewsModel
{
    public class HomeVM
    {
        public IEnumerable<ProfessionUIVM> Professions { get; set; }
        public IEnumerable<TeamUIVM> Teams { get; set; }
    }
}

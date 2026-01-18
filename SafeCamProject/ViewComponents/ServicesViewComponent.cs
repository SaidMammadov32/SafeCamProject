using Microsoft.AspNetCore.Mvc;

namespace SafeCamProject.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

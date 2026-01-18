using Microsoft.AspNetCore.Mvc;

namespace SafeCamProject.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SafeCamProject.ViewComponents
{
    public class PricingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
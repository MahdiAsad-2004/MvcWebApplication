using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteFooter : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("SiteFooter");
        }
    }


   
}

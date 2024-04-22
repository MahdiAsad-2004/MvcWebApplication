using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteHeader : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteHeader");
        }
    }


   
}

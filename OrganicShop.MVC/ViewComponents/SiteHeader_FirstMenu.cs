using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteHeader_FirstMenu : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteHeader_FirstMenu");
        }
    }


   
}

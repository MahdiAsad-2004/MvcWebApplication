using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.Areas.Admin.ViewComponents
{

    public class AdminHeader : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AdminHeader");
        }
    }


   
}

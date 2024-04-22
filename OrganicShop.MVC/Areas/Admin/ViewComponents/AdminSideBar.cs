using Microsoft.AspNetCore.Mvc;


namespace OrganicShop.Mvc.Areas.Admin.ViewComponents
{

    public class AdminSideBar : ViewComponent
    {



        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("AdminSideBar");
        }
    }


   
}

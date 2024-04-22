using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController<HomeController>
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }



        public async Task<IActionResult> Test()
        {
            var t = new Toast(ToastType.Info, "Hiiiiii");
            
            return _ClientHandleResult.PartialThenToast(HttpContext,PartialView("Index"),t);
        }


        


    }
}

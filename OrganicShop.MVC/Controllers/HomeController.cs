using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class HomeController : BaseController<HomeController>
    {

    
        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        public async Task<IActionResult> TestAction()
        {
            await Console.Out.WriteLineAsync();
            var t = new Toast(ToastType.Info, "asdadasd 654654a6d4d6a54d ", 5000);

            //throw new Exception("custom error thrown");

            //ToastOnTempData(t);
            //return RedirectToAction("Index");

            //return _ClientHandleResult.Toast(HttpContext,t);

            return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("Privacy"), t);
            
            //return _ClientHandleResult.Partial(HttpContext, PartialView("Privacy"));

            //return _ClientHandleResult.RedirectThenToast(HttpContext,TempData,"Index",t,true);

            //return _ClientHandleResult.ToastThenRedirect(HttpContext,"Index",t,true);

            //return _ClientHandleResult.ToastThenRfresh(HttpContext,t);

        }



        [HttpPut]
        public async Task<IActionResult> TestAction(string name)
        {
            return Content($"Name: {name}");
        }


        [HttpPost]
        public async Task<IActionResult> TestAction(string name , int number)
        {
            return Content($"Name: {name} ---- Number: {number}");
        }


        [HttpGet("qwe")]
        public IActionResult test()
        {
            return PartialView("_Error404");
        }
    }
}

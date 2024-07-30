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
    public class ErrorController : BaseController<ErrorController>
    {


        [HttpGet("/Error/404")]
        public async Task<IActionResult> NotFound()
        {
            return View();
        } 
        
        [HttpGet("/Error/403")]
        public async Task<IActionResult> Forbidden()
        {
            return View();
        }

        [HttpGet("/Error/401")]
        public async Task<IActionResult> Unauthorized()
        {
            return View();
        }


    }
}

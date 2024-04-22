using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Areas.Admin
{
    [Area("Admin")]
    public class BaseAdminController<TController> : BaseController<TController> where TController : Controller
    {
       
    }



}

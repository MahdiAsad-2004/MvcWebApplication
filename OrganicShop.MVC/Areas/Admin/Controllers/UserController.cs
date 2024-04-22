using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Mvc.Models.Toast;
using OrganicShop.Mvc.Extensions;
using System.Text.Json;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums;
using OrganicShop.BLL.Services;

namespace OrganicShop.Mvc.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController<UserController>
    {
        #region ctor

        private readonly IUserService _UserService;
        private readonly IPermissionService _PermissionService;

        public UserController(IUserService UserService, IPermissionService permissionService)
        {
            _UserService = UserService;
            _PermissionService = permissionService;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> Index(FilterUserDto filter, PagingDto paging)
        {
            filter.ActiveFilter = IsActiveFilter.All;
            var response = await _UserService.GetAll(filter, paging);

            switch (response.Result)
            {
                case ResponseResult.Success:
                    return View("Indexx",response.Data);

                case ResponseResult.NoAccess:
                    return Forbid();

                case ResponseResult.NotFound:
                    return NotFoundPage();

                default:
                    return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> UsersTable(FilterUserDto filter, PagingDto paging)
        {
            var response = await _UserService.GetAll(filter, paging);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Partial(HttpContext, PartialView("_UsersTable", response.Data));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Permissions"] = (await _PermissionService.GetCombos()).Data;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto? createUser)
        {
            if (createUser != null)
            {
                var response = await _UserService.Create(createUser);
                if (response.Result == ResponseResult.Success)
                {
                    ToastOnTempData(new Toast(ToastType.Success, response.Message));
                    return Refresh();
                }
                ToastOnTempData(new Toast(ToastType.Error, response.Message,7000));
                return Refresh();
            }
            else
            {
                ViewData["Permissions"] = (await _PermissionService.GetCombos()).Data;
            }
            return View();
        }



        [HttpGet("Admin/User/{id}/Permissions")]
        public async Task<IActionResult> UserPermissions(long id)
        {
            if (User.GetAppUser().HasPermission(a => a.Giving_Permission))
            {
                await Console.Out.WriteLineAsync("Find");
                var user = await _UserService.Get(id);
                if (user == null)
                {
                    ToastOnTempData(new Toast(ToastType.Error, "کاربر یافت نشد"));
                    return View("Index" , await _UserService.GetAll());
                }
            }
            return Content("sfdsfs");
        }




        public async Task<bool> EmailExist(string email)
            => await _UserService.IsEmailExist(email);

        public async Task<bool> PhoneNumberExist(string phoneNumber)
            => await _UserService.IsPhoneNumberExist(phoneNumber);



        public async Task<IActionResult> Delete(long Id)
        {
            var response = await _UserService.Delete(Id);
            switch (response.Result)
            {
                //case EntityResult.Success:
                    //return Partial("Index", await _UserService.GetAll() , new Toast(ToastType.Success , response.Message , 3000));

                //case EntityResult.NotFound:
                    //return Toast(new Toast(ToastType.Error, response.Message));
                
                default:
                    throw new Exception("Unhandled Entity Result .");
            }
        }
    }
}

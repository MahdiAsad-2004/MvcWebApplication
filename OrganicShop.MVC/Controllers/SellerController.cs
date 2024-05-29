using AutoMapper;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Hangfire.MemoryStorage.Database;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Dtos.SellerDtos;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.UserMessageDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;
using OrganicShop.Ioc;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Extensions;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class SellerController : BaseController<SellerController>
    {
        #region ctor

        private readonly ISellerService _SellerService;
        public SellerController(ISellerService sellerService)
        {
            _SellerService = sellerService;
        }

        #endregion


        [HttpGet("/Sellers")]
        public async Task<IActionResult> Index(PagingDto paging)
        {
            var model = (await _SellerService.GetAllSummary(new FilterSellerDto { SortBy = BaseSortType.Newest }, paging)).Data;
            return View("Index" , model);
        }



        [HttpGet("/Seller/{sellerTitle}")]
        public async Task<IActionResult> Get(string sellerTitle)
        {
            return View("Seller");
        }






    }
}

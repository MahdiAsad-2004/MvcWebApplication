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
    public class HomeController : BaseController<HomeController>
    {
        #region ctor

        private readonly IFaqService _FaqService;
        private readonly IArticleService _ArticleService;
        private readonly IContactUsService _ContactUsService;
        private readonly IUserMessageService _UserMessageService;
        private readonly INewsLetterMemberService _NewsLetterMemberService;
        public HomeController(INewsLetterMemberService newsLetterMemberService, IArticleService articleService,
            IContactUsService contactUsService, IUserMessageService userMessageService, IFaqService faqService)
        {
            _NewsLetterMemberService = newsLetterMemberService;
            _ArticleService = articleService;
            _ContactUsService = contactUsService;
            _UserMessageService = userMessageService;
            _FaqService = faqService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {

            return View("Index");
        }


        [HttpGet("/contact-us")]
        public async Task<IActionResult> ContactUs()
        {
            var model = (await _ContactUsService.Get()).Data;
            return View(model);
        }


        [HttpGet("/about-us")]
        public async Task<IActionResult> AboutUs()
        {
            ViewData["NewestBlogs"] = (await _ArticleService.GetAll(new FilterArticleDto { SortBy = BaseSortType.Newest }, new PagingDto { PageItemsCount = 5 })).Data?.List
                ?? new List<ArticleListDto>();
            return View();
        }




        [HttpGet("/faq")]
        public async Task<IActionResult> Faq()
        {
            var model = (await _FaqService
                .GetAll(new FilterFaqDto { SortBy = BaseSortType.Oldest }, new PagingDto { PageItemsCount = 20 })).Data?.List ?? new List<FaqListDto>();

            return View(model);
        }



        public async Task<IActionResult> SendUserMessage(CreateUserMessageDto createUserMessage)
        {
            if (User.GetAppUser().Id > 0)
                createUserMessage.UserId = User.GetAppUser().Id;

            var response = await _UserMessageService.Create(createUserMessage);
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, response.Message));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message));
        }



        [HttpPost]
        public async Task<IActionResult> SubscribeNewsLetter(CreateNewsLetterMemberDto create)
        {
            var response = await _NewsLetterMemberService.Create(create);
            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.PartialThenToast(HttpContext, PartialView("_NewsLetterSection", new CreateNewsLetterMemberDto())
                    , new Toast(ToastType.Success, response.Message));

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Warning, response.Message));
        }







        [HttpGet("qwe")]
        public IActionResult test()
        {
            return PartialView("_Error404");
        }
    }
}

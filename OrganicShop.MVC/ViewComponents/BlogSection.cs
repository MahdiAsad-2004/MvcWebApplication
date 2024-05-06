using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Services;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;

namespace OrganicShop.MVC.ViewComponents
{
    public class BlogSection : ViewComponent
    {
        #region ctor

        private readonly IArticleService _ArticleService;
        public BlogSection(IArticleService articleService)
        {
            _ArticleService = articleService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            string ip = HttpContext.Connection.RemoteIpAddress.ToString();
            string ipAddress = HttpContext.Request.Headers["HTTP_X_FORWARDED_FOR"];
            string ipAddress1 = HttpContext.Request.Headers["X-Forwarded-For"];
            string ipAddress2 = HttpContext.Request.Headers["REMOTE_ADDR"];
            await Console.Out.WriteLineAsync($"ip: {ip}");
            await Console.Out.WriteLineAsync($"ipAddress: {ipAddress}");
            await Console.Out.WriteLineAsync($"ipAddress1: {ipAddress1}");
            await Console.Out.WriteLineAsync($"ipAddress2: {ipAddress2}");
            var response = await _ArticleService.GetAll(new FilterArticleDto { SortBy = BaseSortType.Newest }, new PagingDto { PageItemsCount = 6 });
            return View("BlogSection", response.Data.List);
        }

    }
}

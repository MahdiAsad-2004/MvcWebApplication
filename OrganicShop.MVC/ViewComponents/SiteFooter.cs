using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteFooter : ViewComponent
    {
        #region constructor

        private readonly ICategoryService _CategoryService;
        private readonly IContactUsService _ContactUsService;
        public SiteFooter(ICategoryService categoryService, IContactUsService contactUsService)
        {
            _CategoryService = categoryService;
            _ContactUsService = contactUsService;
        }

        #endregion



        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["NewestCategoryCombos"] = (await _CategoryService
                .GetCombos(new FilterCategoryDto { SortBy = CategorySortType.Newest })).Data ?? new List<ComboDto<Category>>();

            var model = (await _ContactUsService.Get()).Data;

            return View("SiteFooter",model);
        }
    }


   
}

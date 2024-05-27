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
        public SiteFooter(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        #endregion



        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["NewestCategoryCombos"] = (await _CategoryService
                .GetCombos(new FilterCategoryDto { SortBy = CategorySortType.Newest })).Data ?? new List<ComboDto<Category>>();

            return View("SiteFooter");
        }
    }


   
}

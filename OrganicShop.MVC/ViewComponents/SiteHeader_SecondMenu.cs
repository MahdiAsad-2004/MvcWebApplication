using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IServices;


namespace OrganicShop.Mvc.ViewComponents
{

    public class SiteHeader_SecondMenu : ViewComponent
    {
        #region constructor 

        private readonly ICategoryService _categoryService;

        public SiteHeader_SecondMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["Categories"] = (await _categoryService.GetAll(new FilterCategoryDto { Type = CategoryType.Product })).Data.List;
            return View("SiteHeader_SecondMenu");
        }
    }


   
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;

namespace OrganicShop.Mvc.Controllers
{
    public class CategoryController : BaseController<ProductController>
    {
        #region ctor

        private readonly IProductService _ProductService;
        private readonly ICategoryService _CategoryService;
        public CategoryController(IProductService productService, ICategoryService categoryService)
        {
            _ProductService = productService;
            _CategoryService = categoryService;
        }

        #endregion




       



    }
}

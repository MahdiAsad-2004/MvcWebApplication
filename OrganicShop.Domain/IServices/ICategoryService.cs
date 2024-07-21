using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface ICategoryService : IService<Category>
    {
        Task<ServiceResponse<PageDto<Category, CategoryListDto, int>>> GetAll(FilterCategoryDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<PageDto<Category, CategorySummaryDto, int>>> GetAllSummary(FilterCategoryDto? filter = null, PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateCategoryDto create);

        Task<ServiceResponse<Empty>> Update(UpdateCategoryDto update);
        
        Task<ServiceResponse<Empty>> Delete( int id);

        Task<ServiceResponse<List<ComboDto<Category>>>> GetCombos(FilterCategoryDto? filter = null);

        Task<ServiceResponse<UpdateCategoryDto>> Get(int Id);


    }
}

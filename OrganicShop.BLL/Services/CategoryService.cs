using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Dtos.DiscountDtos;
using FluentValidation;

namespace OrganicShop.BLL.Services
{

    public class CategoryService : Service<Category>, ICategoryService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IValidator<CreateCategoryDto> _ValidatorCreateCategory;
        private readonly IValidator<UpdateCategoryDto> _ValidatorUpdateCategory;

        public CategoryService(IApplicationUserProvider provider, IMapper mapper, ICategoryRepository CategoryRepository,
            IValidator<CreateCategoryDto> validatorCreateCategory, IValidator<UpdateCategoryDto> validatorUpdateCategory) : base(provider)
        {
            _Mapper = mapper;
            _CategoryRepository = CategoryRepository;
            _ValidatorCreateCategory = validatorCreateCategory;
            _ValidatorUpdateCategory = validatorUpdateCategory;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Category, CategoryListDto, int>>> GetAll(FilterCategoryDto? filter = null, PagingDto? paging = null)
        {
            var query = _CategoryRepository.GetQueryable()
                .Include(a => a.Picture)
                .Include(a => a.Parent)
                .AsQueryable();

            if (filter == null) filter = new FilterCategoryDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.ParentId != null)
            {
                if (filter.ParentId != 0) query = query.Where(q => q.ParentId == filter.ParentId);
                else query = query.Where(q => q.ParentId == null);
            }

            if (filter.Type != CategoryType.All)
            {
                if (filter.Type == CategoryType.Product)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Product);
                
                if (filter.Type == CategoryType.Article)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Article);
            }

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Category, CategoryListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CategoryListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Category, CategoryListDto, int>>(ResponseResult.Success, pageDto);
        }

        public async Task<ServiceResponse<PageDto<Category, CategorySummaryDto, int>>> GetAllSummary(FilterCategoryDto? filter = null, PagingDto? paging = null)
        {
            var query = _CategoryRepository.GetQueryable()
                .Include(a => a.Picture)
                .Include(a => a.Products)
                .Include(a => a.Articles)
                .AsQueryable();

            if (filter == null) filter = new FilterCategoryDto();
           
            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.ParentId != null)
            {
                if (filter.ParentId != 0) query = query.Where(q => q.ParentId == filter.ParentId);
                else query = query.Where(q => q.ParentId == null);
            }

            if (filter.Type != CategoryType.All)
            {
                if (filter.Type == CategoryType.Product)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Product);

                if (filter.Type == CategoryType.Article)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Article);
            }

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Category, CategorySummaryDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CategorySummaryDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Category, CategorySummaryDto, int>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<UpdateCategoryDto>> Get(int Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateCategoryDto>(ResponseResult.NotFound, null);

            var entity = await _CategoryRepository.GetQueryable()
                .Include(a => a.Picture)
                .FirstOrDefaultAsync(a => a.Id.Equals(Id));

            if (entity == null)
                return new ServiceResponse<UpdateCategoryDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<UpdateCategoryDto>(ResponseResult.Success, _Mapper.Map<UpdateCategoryDto>(entity));
        }


        public async Task<ServiceResponse<Empty>> Create(CreateCategoryDto create)
        {
            //HasPermission(a => a.Categories_Admin);

            var validationResult = await _ValidatorCreateCategory.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => EF.Functions.Like(a.Title, create.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Title)));

            Category = _Mapper.Map<Category>(create);

            //// Saving Image


            Category.Picture = await create.ImageFile.SavePictureAsync( PathKey.CategoryImages , PictureType.Category);
            Category.Picture.IsMain = true;
            Category.Picture.Type = PictureType.Category;

            await _CategoryRepository.Add(Category, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }


        public async Task<ServiceResponse<Empty>> Update(UpdateCategoryDto update)
        {
            var validationResult = await _ValidatorUpdateCategory.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Category? Category = new Category();

            if (_CategoryRepository.GetQueryable().Any(a => a.Id != update.Id && EF.Functions.Like(a.Title, update.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            Category = await _CategoryRepository.GetQueryableTracking()
                .Include(a => a.Picture)
                .FirstOrDefaultAsync(a => a.Id.Equals(update.Id));

            if (Category == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (update.ImageFile != null)
            {
                if (Category.Picture != null)
                    Category.Picture = await update.ImageFile.SavePictureAsync(Category.Picture, PathKey.CategoryImages);
                else
                    Category.Picture = await update.ImageFile.SavePictureAsync(PathKey.CategoryImages, PictureType.Category);

                Category.Picture.IsMain = true;
                Category.Picture.BaseEntity.LastModified = DateTime.Now;
                Category.Picture.Type = PictureType.Category;
            }

            await _CategoryRepository.Update(_Mapper.Map(update, Category), _AppUserProvider.User.Id);

            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int id)
        {
            Category? Category = await _CategoryRepository.GetAsTracking(id);

            if (Category == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CategoryRepository.SoftDelete(Category, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }


        public async Task<ServiceResponse<List<ComboDto<Category>>>> GetCombos(FilterCategoryDto? filter = null)
        {
            if (filter == null) filter = new FilterCategoryDto();

            var query = _CategoryRepository.GetQueryable();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.ParentId != null)
            {
                if (filter.ParentId != 0) query = query.Where(q => q.ParentId == filter.ParentId);
                else query = query.Where(q => q.ParentId == null);
            }

            if (filter.Type != CategoryType.All)
            {
                if (filter.Type == CategoryType.Product)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Product);

                if (filter.Type == CategoryType.Article)
                    query = query.Where(q => q.Type == CategoryType.All || q.Type == CategoryType.Article);
            }

            #endregion

            var comboDtos = query
              .Select(a => _Mapper.Map<ComboDto<Category>>(a))
              .ToList();

            return new ServiceResponse<List<ComboDto<Category>>>(ResponseResult.Success, comboDtos);
        }
    }
}

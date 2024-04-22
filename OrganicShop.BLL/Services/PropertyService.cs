using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PropertyDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.Combo;

namespace OrganicShop.BLL.Services
{
    public class PropertyService : Service<Property>, IPropertyService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPropertyRepository _PropertyRepository;

        public PropertyService(IApplicationUserProvider provider,IMapper mapper,IPropertyRepository PropertyRepository) : base(provider)
        {
            _Mapper = mapper;
            this._PropertyRepository = PropertyRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Property, PropertyListDto, int>>> GetAll(FilterPropertyDto? filter = null,PagingDto? paging = null)
        {
            var query = _PropertyRepository.GetQueryable();

            if (filter == null) filter = new FilterPropertyDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);
            
            if (filter.IsBase != null)
                query = query.Where(q => q.IsBase == filter.IsBase.Value);

            if (filter.ProductId != null)
                query = query.Where(q => q.ProductId == filter.ProductId);

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy,query);

            #endregion

            PageDto<Property, PropertyListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query,paging).Select(a => _Mapper.Map<PropertyListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Property, PropertyListDto, int>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<UpdatePropertyDto>> Get(int Id)
        {
            var entity = await _PropertyRepository
                .GetAsNoTracking(Id);

            if (entity == null)
                return new ServiceResponse<UpdatePropertyDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<UpdatePropertyDto>(ResponseResult.Success, _Mapper.Map<UpdatePropertyDto>(entity));
        }



        public async Task<ServiceResponse<Empty>> Create(CreatePropertyDto create)
        {
            if (await _PropertyRepository.GetQueryable().AnyAsync(a => a.Title == create.Title))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Title)));

            Property Property = _Mapper.Map<Property>(create);

            Property.IsBase = true;
            Property.BaseId = null;
            Property.Value = string.Empty;

            await _PropertyRepository.Add(Property,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdatePropertyDto update)
        {
            if (await _PropertyRepository.GetQueryable().AnyAsync(a => a.Title == update.Title && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            Property? Property = await _PropertyRepository.GetAsTracking(update.Id);
            
            if (Property == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            Property.IsBase = true;
            Property.BaseId = null;
            Property.Value = string.Empty;

            await _PropertyRepository.Update(_Mapper.Map(update, Property), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }




        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Property? Property = await _PropertyRepository.GetAsTracking(delete);

            if (Property == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _PropertyRepository.SoftDelete(Property, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }








        public async Task<ServiceResponse<List<ComboDto<Property>>>> GetCombos(FilterPropertyDto? filter = null)
        {
            if(filter == null) filter = new();
            var query = _PropertyRepository.GetQueryable();

            #region filter

            if (filter.IsBase != null)
                query = query.Where(a => a.IsBase == filter.IsBase);

            if (filter.ProductId != null)
                query = query.Where(a => a.ProductId.Equals(filter.ProductId));

            #endregion

            var comboDtos = query
                .Select(a => _Mapper.Map<ComboDto<Property>>(a))
                .ToList();
            return new ServiceResponse<List<ComboDto<Property>>>(ResponseResult.Success, comboDtos);
        }




    }

}

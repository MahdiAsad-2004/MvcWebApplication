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
using OrganicShop.Domain.IProviders;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class PropertyService : Service<Property>, IPropertyService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IValidator<CreatePropertyDto> _ValidatorCreateProperty;
        private readonly IValidator<UpdatePropertyDto> _ValidatorUpdateProperty;

        public PropertyService(IApplicationUserProvider provider, IMapper mapper, IPropertyRepository PropertyRepository,
           IValidator<CreatePropertyDto> validatorCreateProperty, IValidator<UpdatePropertyDto> validatorUpdateProperty) : base(provider)
        {
            _Mapper = mapper;
            _PropertyRepository = PropertyRepository;
            _ValidatorCreateProperty = validatorCreateProperty;
            _ValidatorUpdateProperty = validatorUpdateProperty;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Property, PropertyListDto, long>>> GetAll(FilterPropertyDto? filter = null,PagingDto? paging = null)
        {
            var query = _PropertyRepository.GetQueryable();

            if (filter == null) filter = new FilterPropertyDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId != null)
                query = query.Where(q => q.ProductId == filter.ProductId);

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy,query);

            #endregion

            PageDto<Property, PropertyListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query,paging).Select(a => _Mapper.Map<PropertyListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Property, PropertyListDto, long>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<UpdatePropertyDto>> Get(long Id)
        {
            var entity = await _PropertyRepository
                .GetAsNoTracking(Id);

            if (entity == null)
                return new ServiceResponse<UpdatePropertyDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<UpdatePropertyDto>(ResponseResult.Success, _Mapper.Map<UpdatePropertyDto>(entity));
        }



        public async Task<ServiceResponse<Empty>> Create(CreatePropertyDto create)
        {
            var validationResult = await _ValidatorCreateProperty.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Property Property = _Mapper.Map<Property>(create);

            Property.Value = string.Empty;

            await _PropertyRepository.Add(Property,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdatePropertyDto update)
        {
            var validationResult = await _ValidatorUpdateProperty.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Property? Property = await _PropertyRepository.GetAsTracking(update.Id);

            if (Property == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            Property.Value = string.Empty;

            await _PropertyRepository.Update(_Mapper.Map(update, Property), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }




        //public async Task<ServiceResponse<Empty>> Delete(long delete)
        //{
        //    Property? Property = await _PropertyRepository.GetAsTracking(delete);

        //    if (Property == null)
        //        return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

        //    await _PropertyRepository.SoftDelete(Property, _AppUserProvider.User.Id);
        //    return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        //}








        //public async Task<ServiceResponse<List<ComboDto<Property>>>> GetCombos(FilterPropertyDto? filter = null)
        //{
        //    if(filter == null) filter = new();
        //    var query = _PropertyRepository.GetQueryable();

        //    #region filter

        //    if (filter.IsBase != null)
        //        query = query.Where(a => a.IsBase == filter.IsBase);

        //    if (filter.ProductId != null)
        //        query = query.Where(a => a.ProductId.Equals(filter.ProductId));

        //    #endregion

        //    var comboDtos = query
        //        .Select(a => _Mapper.Map<ComboDto<Property>>(a))
        //        .ToList();
        //    return new ServiceResponse<List<ComboDto<Property>>>(ResponseResult.Success, comboDtos);
        //}




    }

}

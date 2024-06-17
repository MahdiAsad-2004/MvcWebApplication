using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Dtos.ShippingMethodDtos;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class ShippingMethodService : Service<ShippingMethod>, IShippingMethodService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IShippingMethodRepository _ShippingMethodRepository;
        private readonly IValidator<CreateShippingMethodDto> _ValidatorCreateShippingMethod;
        private readonly IValidator<UpdateShippingMethodDto> _ValidatorUpdateShippingMethod;

        public ShippingMethodService(IApplicationUserProvider provider, IMapper mapper, IShippingMethodRepository ShippingMethodRepository,
            IValidator<CreateShippingMethodDto> validatorCreateShippingMethod, IValidator<UpdateShippingMethodDto> validatorUpdateShippingMethod) : base(provider)
        {
            _Mapper = mapper;
            _ShippingMethodRepository = ShippingMethodRepository;
            _ValidatorCreateShippingMethod = validatorCreateShippingMethod;
            _ValidatorUpdateShippingMethod = validatorUpdateShippingMethod;
        }

        #endregion


        public async Task<ServiceResponse<List<ShippingMethodListDto>>> GetAll()
        {
            var query = _ShippingMethodRepository.GetQueryable();

            var list = await query
                .Select(a => _Mapper.Map<ShippingMethodListDto>(a))
                .ToListAsync();

            return new ServiceResponse<List<ShippingMethodListDto>>(ResponseResult.Success,list);
        }


        public async Task<ServiceResponse<ShippingMethodListDto>> Get(byte ShippingMethodId)
        {
            if (ShippingMethodId > 0 == false)
                return new ServiceResponse<ShippingMethodListDto>(ResponseResult.NotFound, _Message.NotFound(), null);

            var ShippingMethod = await _ShippingMethodRepository.GetAsNoTracking(ShippingMethodId);

            if(ShippingMethod == null)
                return new ServiceResponse<ShippingMethodListDto>(ResponseResult.NotFound, _Message.NotFound(), null);

            return new ServiceResponse<ShippingMethodListDto>(ResponseResult.Success , _Mapper.Map<ShippingMethodListDto>(ShippingMethod));
        }



        public async Task<ServiceResponse<Empty>> Create(CreateShippingMethodDto create)
        {
            var validationResult = await _ValidatorCreateShippingMethod.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            ShippingMethod ShippingMethod = _Mapper.Map<ShippingMethod>(create);
            await _ShippingMethodRepository.Add(ShippingMethod,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateShippingMethodDto update)
        {
            var validationResult = await _ValidatorUpdateShippingMethod.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            ShippingMethod? ShippingMethod = await _ShippingMethodRepository.GetAsTracking(update.Id);
            
            if (ShippingMethod == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _ShippingMethodRepository.Update(_Mapper.Map<ShippingMethod>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(byte delete)
        {

            ShippingMethod? ShippingMethod = await _ShippingMethodRepository.GetAsTracking(delete);

            if (ShippingMethod == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _ShippingMethodRepository.SoftDelete(ShippingMethod, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }


    }
}

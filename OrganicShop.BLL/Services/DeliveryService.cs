using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.DeliveryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace OrganicShop.BLL.Services
{
    public class DeliveryService : Service<Delivery>, IDeliveryService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IDeliveryRepository _DeliveryRepository;

        public DeliveryService(IApplicationUserProvider provider,IMapper mapper,IDeliveryRepository DeliveryRepository) : base(provider)
        {
            _Mapper = mapper;
            _DeliveryRepository = DeliveryRepository;
        }

        #endregion


        public async Task<ServiceResponse<List<DeliveryListDto>>> GetAll()
        {
            var query = _DeliveryRepository.GetQueryable();

            var list = await query
                .Select(a => _Mapper.Map<DeliveryListDto>(a))
                .ToListAsync();

            return new ServiceResponse<List<DeliveryListDto>>(ResponseResult.Success,list);
        }


        public async Task<ServiceResponse<DeliveryListDto>> Get(byte deliveryId)
        {
            if (deliveryId > 0 == false)
                return new ServiceResponse<DeliveryListDto>(ResponseResult.NotFound, _Message.NotFound(), null);

            var delivery = await _DeliveryRepository.GetAsNoTracking(deliveryId);

            if(delivery == null)
                return new ServiceResponse<DeliveryListDto>(ResponseResult.NotFound, _Message.NotFound(), null);

            return new ServiceResponse<DeliveryListDto>(ResponseResult.Success , _Mapper.Map<DeliveryListDto>(delivery));
        }



        public async Task<ServiceResponse<Empty>> Create(CreateDeliveryDto create)
        {
            Delivery Delivery = _Mapper.Map<Delivery>(create);
            await _DeliveryRepository.Add(Delivery,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateDeliveryDto update)
        {
            Delivery? Delivery = await _DeliveryRepository.GetAsTracking(update.Id);
            
            if (Delivery == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _DeliveryRepository.Update(_Mapper.Map<Delivery>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(byte delete)
        {

            Delivery? Delivery = await _DeliveryRepository.GetAsTracking(delete);

            if (Delivery == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _DeliveryRepository.SoftDelete(Delivery, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }


    }
}

using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Services
{
    public class TrackingDescriptionService : Service<TrackingDescription>, ITrackingDescriptionService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ITrackingDescriptionRepository _TrackingDescriptionRepository;
        private readonly IOrderRepository _OrderRepository;

        public TrackingDescriptionService(IApplicationUserProvider provider,IMapper mapper,ITrackingDescriptionRepository TrackingDescriptionRepository,
            IOrderRepository orderRepository) : base(provider)
        {
            _Mapper = mapper;
            _TrackingDescriptionRepository = TrackingDescriptionRepository;
            _OrderRepository = orderRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<TrackingDescription, TrackingDescriptionListDto, long>>> GetAll
            (FilterTrackingDescriptionDto? filter = null ,PagingDto? paging = null)
        {
            var query = _TrackingDescriptionRepository.GetQueryable();

            if (filter == null) filter = new FilterTrackingDescriptionDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.StartDate != null)
                query = query.Where(q => q.Date >= filter.StartDate);

            if (filter.EndDate != null)
                query = query.Where(q => q.Date <= filter.EndDate);

            if (filter.OrderId > 0)
                query = query.Where(q => q.OrderId == filter.OrderId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<TrackingDescription, TrackingDescriptionListDto,long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<TrackingDescriptionListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<TrackingDescription, TrackingDescriptionListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateTrackingDescriptionDto create)
        {
            TrackingDescription TrackingDescription = _Mapper.Map<TrackingDescription>(create);

            #region relation

            if (await _OrderRepository.GetQueryable().AnyAsync(a => a.Id == create.OrderId) == false)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound(typeof(Order)));

            #endregion

            await _TrackingDescriptionRepository.Add(TrackingDescription,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateTrackingDescriptionDto update)
        {
            TrackingDescription? TrackingDescription = await _TrackingDescriptionRepository.GetAsTracking(update.Id);
            
            if (TrackingDescription == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            #region relation

            if (await _OrderRepository.GetQueryable().AnyAsync(a => a.Id == update.OrderId) == false)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound(typeof(Order)));

            #endregion

            await _TrackingDescriptionRepository.Update(_Mapper.Map<TrackingDescription>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            TrackingDescription? TrackingDescription = await _TrackingDescriptionRepository.GetAsTracking(delete);

            if (TrackingDescription == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound())      ;

            await _TrackingDescriptionRepository.SoftDelete(TrackingDescription, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}

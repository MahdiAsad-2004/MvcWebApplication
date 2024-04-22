using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class TrackingStatusService : Service<TrackingStatus>, ITrackingStatusService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ITrackingStatusRepository _TrackingStatusRepository;
        private readonly IOrderRepository _OrderRepository;

        public TrackingStatusService(IApplicationUserProvider provider,IMapper mapper,ITrackingStatusRepository TrackingStatusRepository,
            IOrderRepository orderRepository) : base(provider)
        {
            _Mapper = mapper;
            _TrackingStatusRepository = TrackingStatusRepository;
            _OrderRepository = orderRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<TrackingStatus, TrackingStatusListDto, long>>> GetAll
            (FilterTrackingStatusDto? filter = null,PagingDto? paging = null)
        {
            var query = _TrackingStatusRepository.GetQueryable();

            if (filter == null) filter = new FilterTrackingStatusDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.DoneStatus != null)
                query = query.Where(q => q.DoneStatus >= filter.DoneStatus);

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy,query);

            #endregion

            PageDto<TrackingStatus, TrackingStatusListDto,long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<TrackingStatusListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<TrackingStatus, TrackingStatusListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateTrackingStatusDto create)
        {
            //TrackingStatus TrackingStatus = create.ToModel();

            if (_OrderRepository.GetQueryable().Any(a => a.Id == create.OrderId) == false)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound(typeof(Order)));

            if(_TrackingStatusRepository.GetQueryable().Any(a => a.OrderId == create.OrderId) == true)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "! وضعیت های سفارش قبلا ایجاد شده است");

            var TrackingStatuses = Enumerable.Empty<TrackingStatus>();
            foreach (var orderStep in EnumExtension.GetArray<OrderStep>())
            {
                TrackingStatuses.Append(new TrackingStatus
                {
                    Step = orderStep,
                    DoneStatus = DoneStatus.Waiting,
                    DoneDate = null,
                    OrderId = create.OrderId,
                    BaseEntity = new BaseEntity(true),
                });
            }

            await _TrackingStatusRepository.Add(TrackingStatuses.ToList(),_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateTrackingStatusDto update)
        {
            TrackingStatus? TrackingStatus = await _TrackingStatusRepository.GetAsTracking(update.Id);
            
            if (TrackingStatus == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _TrackingStatusRepository.Update(_Mapper.Map<TrackingStatus>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            TrackingStatus? TrackingStatus = await _TrackingStatusRepository.GetAsTracking(delete);

            if (TrackingStatus == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _TrackingStatusRepository.SoftDelete(TrackingStatus, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}

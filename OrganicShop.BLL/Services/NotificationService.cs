using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NotificationDtos;
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
using OrganicShop.Domain.Dtos.Combo;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly INotificationRepository _NotificationRepository;
        private readonly IValidator<CreateNotificationDto> _ValidatorCreateNotification;
        private readonly IValidator<UpdateNotificationDto> _ValidatorUpdateNotification;

        public NotificationService(IApplicationUserProvider provider, IMapper mapper, INotificationRepository NotificationRepository,
            IValidator<CreateNotificationDto> validatorCreateNotification, IValidator<UpdateNotificationDto> validatorUpdateNotification) : base(provider)
        {
            _Mapper = mapper;
            _NotificationRepository = NotificationRepository;
            _ValidatorCreateNotification = validatorCreateNotification;
            _ValidatorUpdateNotification = validatorUpdateNotification;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Notification, NotificationListDto, int>>> GetAll(FilterNotificationDto? filter = null,PagingDto? paging = null)
        {
            var query = _NotificationRepository.GetQueryable();

            if (filter == null) filter = new FilterNotificationDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Text != null)
                query = query.Where(q => EF.Functions.Like(q.TextHtml, $"%{filter.Text}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Notification, NotificationListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<NotificationListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Notification, NotificationListDto, int>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<UpdateNotificationDto>> Get(int Id)
        {
            if(Id < 1)
                return new ServiceResponse<UpdateNotificationDto>(ResponseResult.NotFound,null);
            
            var Notification = await _NotificationRepository.GetAsNoTracking(Id);
            
            if(Notification == null)
                return new ServiceResponse<UpdateNotificationDto>(ResponseResult.NotFound,null);

            return new ServiceResponse<UpdateNotificationDto>(ResponseResult.Success, _Mapper.Map<UpdateNotificationDto>(Notification));
        }


        public async Task<ServiceResponse<Empty>> Create(CreateNotificationDto create)
        {
            var validationResult = await _ValidatorCreateNotification.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Notification Notification = _Mapper.Map<Notification>(create);

            await _NotificationRepository.Add(Notification,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateNotificationDto update)
        {
            var validationResult = await _ValidatorUpdateNotification.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Notification? Notification = await _NotificationRepository.GetAsTracking(update.Id);
            
            if (Notification == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _NotificationRepository.Update(_Mapper.Map(update,Notification), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Notification? Notification = await _NotificationRepository.GetAsTracking(delete);

            if (Notification == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _NotificationRepository.SoftDelete(Notification, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<List<ComboDto<Notification>>>> GetCombos()
        {
            var comboDtos = _NotificationRepository
              .GetQueryable()
              .Select(a => _Mapper.Map<ComboDto<Notification>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Notification>>>(ResponseResult.Success, comboDtos);
        }



    }
}

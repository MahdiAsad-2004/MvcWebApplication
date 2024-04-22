﻿using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.FaqDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;

namespace OrganicShop.BLL.Services
{
    public class FaqService : Service<Faq>, IFaqService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IFaqRepository _FaqRepository;

        public FaqService(IApplicationUserProvider provider,IMapper mapper,IFaqRepository FaqRepository) : base(provider)
        {
            _Mapper = mapper;
            _FaqRepository = FaqRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Faq, FaqListDto, byte>>> GetAll(FilterFaqDto? filter = null, PagingDto? paging = null)
        {
            var query = _FaqRepository.GetQueryable();

            if (filter == null) filter = new FilterFaqDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.QuestionText != null)
                query = query.Where(q => EF.Functions.Like(q.QuestionText, $"%{filter.QuestionText}%"));

            if (filter.AnswerText != null)
                query = query.Where(q => EF.Functions.Like(q.AnswerText, $"%{filter.AnswerText}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy,query);

            #endregion

            PageDto<Faq, FaqListDto, byte> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<FaqListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Faq, FaqListDto, byte>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateFaqDto create)
        {
            Faq Faq = _Mapper.Map<Faq>(create);
            await _FaqRepository.Add(Faq,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateFaqDto update)
        {
            Faq? Faq = await _FaqRepository.GetAsTracking(update.Id);
            
            if (Faq == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _FaqRepository.Update(_Mapper.Map<Faq>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(byte delete)
        {

            Faq? Faq = await _FaqRepository.GetAsTracking(delete);

            if (Faq == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _FaqRepository.SoftDelete(Faq, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}

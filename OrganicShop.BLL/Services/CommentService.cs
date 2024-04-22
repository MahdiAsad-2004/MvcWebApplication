using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums.Response;
using Microsoft.EntityFrameworkCore;

namespace OrganicShop.BLL.Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ICommentRepository _CommentRepository;

        public CommentService(IApplicationUserProvider provider, IMapper mapper, ICommentRepository CommentRepository) : base(provider)
        {
            _Mapper = mapper;
            this._CommentRepository = CommentRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Comment, CommentListDto, long>>> GetAll(FilterCommentDto? filter = null, PagingDto? paging = null)
        {
            var query = _CommentRepository.GetQueryable()
                .Include(a => a.User)
                .Include(a => a.Product)
                .AsQueryable();

            if (filter == null) filter = new FilterCommentDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Status != null)
                query = query.Where(q => q.Status == filter.Status);

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Comment, CommentListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<CommentListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Comment, CommentListDto, long>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<CommentListDto>> Get(long Id)
        {
            if (Id < 1)
                return new ServiceResponse<CommentListDto>(ResponseResult.NotFound, null);

            var comment = await _CommentRepository.GetAsNoTracking(Id);

            if (comment != null)
                return new ServiceResponse<CommentListDto>(ResponseResult.Success, _Mapper.Map<CommentListDto>(comment));

            return new ServiceResponse<CommentListDto>(ResponseResult.NotFound, null);
        }


        public async Task<ServiceResponse<Empty>> Create(CreateCommentDto create)
        {
            Comment Comment = _Mapper.Map<Comment>(create);
            Comment.Status = CommentStatus.Unread;
            await _CommentRepository.Add(Comment, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateCommentDto update)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(update.Id);

            if (Comment == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CommentRepository.Update(_Mapper.Map<Comment>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Comment? Comment = await _CommentRepository.GetAsTracking(delete);

            if (Comment == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _CommentRepository.SoftDelete(Comment, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }
    }
}

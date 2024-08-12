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
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using OrganicShop.Domain.Validation.CommentValidators;

namespace OrganicShop.BLL.Services
{
    public class CommentService : Service<Comment>, ICommentService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IUserRepository _UserRepository;
        private readonly ICommentRepository _CommentRepository;
        private readonly IProductRepository _ProductRepository;
        private readonly ISellerRepository _SellerRepository;
        private readonly IArticleRepository _ArticleRepository;
        private readonly IValidator<CreateCommentDto> _ValidatorCreateComment;
        private readonly IValidator<UpdateCommentDto> _ValidatorUpdateComment;
        private readonly IValidator<CreateCommentFeedbackUserDto> _ValidatorCreateCommentFeedbackUser;

        public CommentService(IApplicationUserProvider provider, IMapper mapper, ICommentRepository CommentRepository,
            IValidator<CreateCommentDto> validatorCreateComment, IValidator<UpdateCommentDto> validatorUpdateComment,
            IValidator<CreateCommentFeedbackUserDto> validatorCreateCommentFeedbackUser, IProductRepository productRepository,
            ISellerRepository sellerRepository, IArticleRepository articleRepository, IUserRepository userRepository) : base(provider)
        {
            _Mapper = mapper;
            this._CommentRepository = CommentRepository;
            _ValidatorCreateComment = validatorCreateComment;
            _ValidatorUpdateComment = validatorUpdateComment;
            _ValidatorCreateCommentFeedbackUser = validatorCreateCommentFeedbackUser;
            _ProductRepository = productRepository;
            _SellerRepository = sellerRepository;
            _ArticleRepository = articleRepository;
            _UserRepository = userRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Comment, CommentListDto, long>>> GetAll(FilterCommentDto? filter = null, PagingDto? paging = null)
        {
            var query = _CommentRepository.GetQueryable()
                .Include(a => a.User)
                    .ThenInclude(a => a.Picture)
                .AsQueryable();

            if (filter == null) filter = new FilterCommentDto();

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


        //public async Task<ServiceResponse<Empty>> Create(CreateCommentDto? create = null, CreateCommentFeedbackUserDto? createForUser = null)
        //{
        //    var validationResult = await _ValidatorCreateComment.ValidateAsync(create);
        //    if (!validationResult.IsValid)
        //        return new ServiceResponse<Empty>(create, validationResult);

        //    if (create == null && createForUser == null)
        //        throw new ArgumentNullException("CreateCommentDto and CreateCommentUserDto are null !");

        //    Comment Comment = _Mapper.Map<Comment>(create);
        //    Comment.Status = CommentStatus.Unread;

        //    if (createForUser != null)
        //    {
        //        if (_AppUserProvider.User.Id < 1)
        //            return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NoAccess());
        //        Comment.UserId = _AppUserProvider.User.Id;
        //    }

        //    await _CommentRepository.Add(Comment, _AppUserProvider.User.Id);
        //    return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        //}




        public async Task<ServiceResponse<Empty>> Create(CreateCommentFeedbackUserDto createForUser)
        {
            var validationResult = await _ValidatorCreateCommentFeedbackUser.ValidateAsync(createForUser);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(createForUser, validationResult);

            if (createForUser.ProductId == null && createForUser.SellerId == null)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "مقصد بازخورد انتخاب نشده است");

            if (createForUser.ProductId != null)
            {
                if (await _ProductRepository.GetQueryable().AnyAsync(a => a.Id == createForUser.ProductId) == false)
                    return new ServiceResponse<Empty>(ResponseResult.NotFound, "محصول مورد نطر وجود ندارد");
            }
            else
            {
                if (await _SellerRepository.GetQueryable().AnyAsync(a => a.Id == createForUser.SellerId) == false)
                    return new ServiceResponse<Empty>(ResponseResult.NotFound, "فروشنده مورد نطر وجود ندارد");
            }

            Comment Comment = _Mapper.Map<Comment>(createForUser);
            await _CommentRepository.Add(Comment, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, "بازخورد شما با موفقیت ثبت شد و پس از بررسی نمایش داده میشود");
        }


        public async Task<ServiceResponse<Empty>> Create(CreateCommentDto create)
        {
            var validationResult = await _ValidatorCreateComment.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            if (create.UserId > 0)
                if (await _UserRepository.GetQueryable().AnyAsync(a => a.Id == create.UserId) == false)
                    return new ServiceResponse<Empty>(ResponseResult.NotFound, "حساب کاربری شما یافت نشد");

            if (create.ArticleId > 0 == false)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, "مقاله مورد نطر وجود ندارد");

            if (await _ArticleRepository.GetQueryable().AnyAsync(a => a.Id == create.ArticleId) == false)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, "مقاله مورد نطر وجود ندارد");

            Comment Comment = _Mapper.Map<Comment>(create);
            await _CommentRepository.Add(Comment, create.UserId != null ? create.UserId.Value : 1);
            return new ServiceResponse<Empty>(ResponseResult.Success, "نطر شما با موفقیت ثبت شد و پس از بررسی نمایش داده میشود");
        }






        public async Task<ServiceResponse<Empty>> Update(UpdateCommentDto update)
        {
            var validationResult = await _ValidatorUpdateComment.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

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

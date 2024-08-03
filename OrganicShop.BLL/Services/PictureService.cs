using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.BLL.Extensions;

namespace OrganicShop.BLL.Services
{
    public class PictureService : Service<Picture>, IPictureService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPictureRepository _PictureRepository;


        public PictureService(IApplicationUserProvider provider, IMapper mapper, IPictureRepository PictureRepository) : base(provider)
        {
            _Mapper = mapper;
            _PictureRepository = PictureRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Picture, PictureListDto, long>>> GetAll(FilterPictureDto? filter = null, PagingDto? paging = null)
        {
            var query = _PictureRepository.GetQueryable();

            if (filter == null) filter = new FilterPictureDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Name != null)
                query = query.Where(q => EF.Functions.Like(q.Name, $"%{filter.Name}%"));

            if (filter.MinSize != null)
                query = query.Where(a => a.SizeMB >= filter.MinSize);

            if (filter.MaxSize != null)
                query = query.Where(a => a.SizeMB <= filter.MaxSize);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Picture, PictureListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<PictureListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Picture, PictureListDto, long>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreatePictureDto create)
        {

            throw new NotImplementedException();
        }



        public async Task<ServiceResponse<Empty>> Update(UpdatePictureDto update)
        {
            // validate object

            var picture = await _PictureRepository.GetAsTracking(update.Id);

            //await _PictureRepository.Update(_Mapper.Map(update, picture));
            

                throw new NotImplementedException();
        }




        //public async Task<ServiceResponse<Empty>> Upsert(UpdatePictureDto updatePicture)
        //{
        //    // validate object

        //    var picture = await _PictureRepository.GetAsTracking();

        //    await _PictureRepository.Update(_Mapper.Map(updatePicture , ))
        //}



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Picture? Picture = await _PictureRepository.GetAsTracking(delete);

            if (Picture == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.SuccessDelete());

            //await _PictureRepository.SoftDelete(Picture, _AppUserProvider.User.Id);
            if (await Picture.DeletePictureFile())
            {
                await _PictureRepository.Delete(Picture, _AppUserProvider.User.Id);
                return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
            }
            return new ServiceResponse<Empty>(ResponseResult.Failed, "فایل مورد نطر یافت نشد !");
        }
    }
}

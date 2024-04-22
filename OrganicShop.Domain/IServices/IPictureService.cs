using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IPictureService : IService<Picture>
    {
        Task<ServiceResponse<PageDto<Picture, PictureListDto, long>>> GetAll(FilterPictureDto? filter = null ,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreatePictureDto create);

        Task<ServiceResponse<Empty>> Update(UpdatePictureDto update);
        
        Task<ServiceResponse<Empty>> Delete(long delete);
        
    }
}

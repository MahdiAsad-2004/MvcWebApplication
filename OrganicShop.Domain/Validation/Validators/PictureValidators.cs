using FluentValidation;
using OrganicShop.Domain.Dtos.PictureDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.PictureValidators
{
    public class CreatePictureValidator : BaseValidator<CreatePictureDto>
    {
        public CreatePictureValidator()
        {


        }
    }


    public class UpdatePictureValidator : BaseValidator<UpdatePictureDto>
    {
        public UpdatePictureValidator()
        {
         

        }
    }



}

using FluentValidation;
using OrganicShop.Domain.Dtos.TrackingDescriptionDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.TrackingDescriptionValidators
{
    public class CreateTrackingDescriptionValidator : BaseValidator<CreateTrackingDescriptionDto>
    {
        public CreateTrackingDescriptionValidator()
        {


        }
    }


    public class UpdateTrackingDescriptionValidator : BaseValidator<UpdateTrackingDescriptionDto>
    {
        public UpdateTrackingDescriptionValidator()
        {
         

        }
    }



}

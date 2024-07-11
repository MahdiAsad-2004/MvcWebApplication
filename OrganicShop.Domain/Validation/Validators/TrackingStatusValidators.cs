using FluentValidation;
using OrganicShop.Domain.Dtos.TrackingStatusDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.TrackingStatusValidators
{
    public class CreateTrackingStatusValidator : BaseValidator<CreateTrackingStatusDto>
    {
        public CreateTrackingStatusValidator()
        {


        }
    }


    public class UpdateTrackingStatusValidator : BaseValidator<UpdateTrackingStatusDto>
    {
        public UpdateTrackingStatusValidator()
        {
         

        }
    }



}

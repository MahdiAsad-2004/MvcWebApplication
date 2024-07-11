
using FluentValidation;
using OrganicShop.Domain.Dtos.NotificationDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.NotificationValidators
{
    public class CreateNotificationValidator : BaseValidator<CreateNotificationDto>
    {
        public CreateNotificationValidator()
        {


        }
    }


    public class UpdateNotificationValidator : BaseValidator<UpdateNotificationDto>
    {
        public UpdateNotificationValidator()
        {
         

        }
    }



}

using FluentValidation;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.PermissionValidators
{
    public class CreatePermissionValidator : BaseValidator<CreatePermissionDto>
    {
        public CreatePermissionValidator()
        {


        }
    }


    public class UpdatePermissionValidator : BaseValidator<UpdatePermissionDto>
    {
        public UpdatePermissionValidator()
        {
         

        }
    }



}

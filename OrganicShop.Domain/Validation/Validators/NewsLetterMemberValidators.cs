using FluentValidation;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.NewsLetterMemberValidators
{
    public class CreateNewsLetterMemberValidator : BaseValidator<CreateNewsLetterMemberDto>
    {
        public CreateNewsLetterMemberValidator()
        {


        }
    }


    public class UpdateNewsLetterMemberValidator : BaseValidator<UpdateNewsLetterMemberDto>
    {
        public UpdateNewsLetterMemberValidator()
        {
         

        }
    }



}

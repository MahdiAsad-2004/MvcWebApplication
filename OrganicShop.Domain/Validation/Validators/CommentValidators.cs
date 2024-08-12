using FluentValidation;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.CommentValidators
{
    public class CreateCommentValidator : BaseValidator<CreateCommentDto>
    {
        public CreateCommentValidator()
        {


        }
    }


    public class UpdateCommentValidator : BaseValidator<UpdateCommentDto>
    {
        public UpdateCommentValidator()
        {
         

        }
    }
    

    public class CreateCommentFeedbackUserValidator : BaseValidator<CreateCommentFeedbackUserDto>
    {
        public CreateCommentFeedbackUserValidator()
        {
            

        }
    }



}

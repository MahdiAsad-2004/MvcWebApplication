using FluentValidation;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.ArticleValidators
{
    public class CreateArticleValidator : BaseValidator<CreateArticleDto>
    {
        public CreateArticleValidator()
        {


        }
    }


    public class UpdateArticleValidator : BaseValidator<UpdateArticleDto>
    {
        public UpdateArticleValidator()
        {
         

        }
    }



}

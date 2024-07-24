using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Services;
using OrganicShop.BLL.Utils;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;

namespace OrganicShop.MVC.ViewComponents
{
    public class SendCommentSection : ViewComponent
    {
        #region ctor

        private readonly AesKeys _AesKeys;
        public SendCommentSection(IOptions<AesKeys> aesKeys)
        {
            _AesKeys = aesKeys.Value;
        }

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? credentialForCommentCrypted = HttpContext.Request.Cookies[AppCookies.NameAndEmailForComment.Key];
            CredentialForCommentDto? credentialForCommentDto = AppCookies.NameAndEmailForComment
                .GetModel(AesOperation.Decrypt(credentialForCommentCrypted, _AesKeys.Cookie));

            var createComment = new CreateCommentDto();
            if (credentialForCommentDto != null)
            {
                createComment.AuthorName = credentialForCommentDto.AuthorName;
                createComment.Email = credentialForCommentDto.Email;
            }
            createComment.ProductId = ViewComponentContext.Arguments["ProductId"] as long?;
            createComment.ArticleId = ViewComponentContext.Arguments["ArticleId"] as int?;
            return View("SendCommentSection", createComment);
        }

    }
}

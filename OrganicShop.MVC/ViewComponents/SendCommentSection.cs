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
            string NameSavedForCommentCoded = HttpContext.Request.Cookies["NameSavedForComment"];
            string EmailSavedForCommentCoded = HttpContext.Request.Cookies["EmailSavedForComment"];
            var createComment = new CreateCommentDto();
            if(string.IsNullOrEmpty(NameSavedForCommentCoded) == false)
            {
                createComment.AuthorName = AesOperation.Decrypt(NameSavedForCommentCoded, _AesKeys.Cookie) ?? string.Empty;
                //ViewBag.NameSavedForComment = AesOperation.Decrypt(NameSavedForCommentCoded, _AesKeys.Cookie);
            }
            if (string.IsNullOrEmpty(EmailSavedForCommentCoded) == false)
            {
                createComment.Email = AesOperation.Decrypt(EmailSavedForCommentCoded, _AesKeys.Cookie) ?? string.Empty;
                //ViewBag.EmailSavedForComment = AesOperation.Decrypt(EmailSavedForCommentCoded, _AesKeys.Cookie);
            }
            return View("SendCommentSection" , createComment);
        }

    }
}

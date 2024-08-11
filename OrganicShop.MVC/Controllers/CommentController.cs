using Microsoft.AspNetCore.Mvc;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Dtos.CategoryDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Models.Toast;
using Microsoft.AspNetCore.Authorization;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using Microsoft.Extensions.Options;

namespace OrganicShop.Mvc.Controllers
{
    public class CommentController : BaseController<CommentController>
    {
        #region ctor

        private readonly ICommentService _CommentService;
        private readonly AesKeys _AesKeys;
        public CommentController(ICommentService CommentService , IOptions<AesKeys> options)
        {
            _CommentService = CommentService;
            _AesKeys = options.Value;
        }

        #endregion


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateForUser(CreateCommentFeedbackUserDto create)
        {
            create.UserId = AppUser.Id;
            var response = await _CommentService.Create(createForUser: create);

            if(response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext ,new Toast(ToastType.Success, "دیدگاه شما با موفقیت ارسال شد"));
            
            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message) , responseResult:false);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto create)
        {
            var response = await _CommentService.Create(create: create);

            if (response.Result == ResponseResult.Success)
            {
                if (create.SaveNameAndEmail)
                {
                    HttpContext.Response.Cookies.Append
                        (AppCookies.NameAndEmailForComment.Key,
                        AesOperation.Encrypt(AppCookies.NameAndEmailForComment.GenerateJsonValue(new CredentialForCommentDto { AuthorName = create.AuthorName, Email = create.Email }), _AesKeys.Cookie), 
                        AppCookies.NameAndEmailForComment.Options);
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, "دیدگاه شما با موفقیت ارسال شد"));
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message) , responseResult:false);
        }



    }
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.CommentDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.SortTypes;
using OrganicShop.Domain.IServices;
using OrganicShop.Mvc.Controllers.Base;
using OrganicShop.Mvc.Extensions;
using OrganicShop.Mvc.Models.Toast;
using Microsoft.AspNetCore.Authorization;
using OrganicShop.BLL.Providers;
using OrganicShop.BLL.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;

namespace OrganicShop.Mvc.Controllers
{
    public class CommentController : BaseController<CommentController>
    {
        #region ctor

        private readonly AesKeys _AesKeys;
        private readonly ICommentService _CommentService;
        public CommentController(ICommentService CommentService, IOptions<AesKeys> options)
        {
            _CommentService = CommentService;
            _AesKeys = options.Value;
        }

        #endregion



        [Authorize]
        [HttpPost("/feedback/user/add")]
        public async Task<IActionResult> AddFeedback(CreateCommentFeedbackUserDto createComment)
        {
            createComment.UserId = AppUser.Id;
            var response = await _CommentService.Create(createComment);

            if (response.Result == ResponseResult.Success)
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, response.Message));

            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationErrors);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_AddFeedbackModalForm", createComment), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);

        }

        [Authorize]
        [HttpPost("/comment/user/add")]
        public async Task<IActionResult> AddCommentUser(CreateCommentDto create)
        {
            create.UserId = AppUser.Id;
            var response = await _CommentService.Create(create);

            if (response.Result == ResponseResult.Success)
            {
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, response.Message));
            }

            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationErrors);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_SendCommentUserSection", create), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }



        [HttpPost("/comment/unknown/add")]
        public async Task<IActionResult> AddCommentUnknown(CreateCommentDto create)
        {
            var response = await _CommentService.Create(create);

            if (response.Result == ResponseResult.Success)
            {
                if (create.SaveNameAndEmail)
                {
                    HttpContext.Response.Cookies.Append
                    (AppCookies.NameAndEmailForComment.Key,
                    AesOperation.Encrypt(AppCookies.NameAndEmailForComment
                            .GenerateJsonValue(new CredentialForCommentDto { AuthorName = create.AuthorName, Email = create.Email }), _AesKeys.Cookie),
                        AppCookies.NameAndEmailForComment.Options);
                }
                return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Success, response.Message));
            }

            if (response.Result == ResponseResult.ValidationError)
            {
                AddErrorsToModelState(ModelState, response.ValidationErrors);
                return _ClientHandleResult.Partial(HttpContext, PartialView("_SendCommentUnknownSection", create), responseResult: false);
            }

            return _ClientHandleResult.Toast(HttpContext, new Toast(ToastType.Error, response.Message), responseResult: false);
        }



    }
}

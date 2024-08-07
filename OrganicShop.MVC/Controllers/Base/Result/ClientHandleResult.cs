﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.Mvc.Models.Redirect;
using OrganicShop.Mvc.Models.Toast;
using System.Text.Json;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.Mvc.Controllers.Base.Result
{
    public class ClientHandleResult<TController> where TController : Controller
    {

        #region private methods

        private string GetAreaName()
        {
            var areaAttribute = typeof(TController).GetCustomAttribute<AreaAttribute>();
            if (areaAttribute != null)
            {
                return $"/{areaAttribute.RouteValue}";
            }
            return string.Empty;
        }
        private string GetUrl(string action)
        {
            string area = GetAreaName();
            string controller = string.Concat('/', typeof(TController).Name.Replace("Controller", null));
            if (action.Contains("index", StringComparison.OrdinalIgnoreCase))
            {
                action = "/";
            }
            else
            {
                action = string.Concat('/', action);
            }
            Console.WriteLine(action);
            return string.Concat(area, controller, action);
        }
        private string GetUrl(string action, string controller)
        {
            string area = GetAreaName();
            controller = $"/{controller}";
            if (action.Contains("index", StringComparison.OrdinalIgnoreCase))
            {
                action = "/";
            }
            else
            {
                action = string.Concat('/', action);
            }
            Console.WriteLine(action);
            return string.Concat(area, controller, action);
        }
        private string GetUrl(string action, string controller, object routeValues)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string area = GetAreaName();
            controller = $"/{controller}";
            if (action.Contains("index", StringComparison.OrdinalIgnoreCase))
            {
                action = "/";
            }
            else
            {
                action = string.Concat('/', action);
            }
            stringBuilder.Append(area);
            stringBuilder.Append(controller);
            stringBuilder.Append(action);
            stringBuilder.Append('?');
            foreach (var item in routeValues.GetType().GetProperties())
            {
                stringBuilder.Append(item.Name);
                stringBuilder.Append('=');
                stringBuilder.Append(item.GetValue(routeValues));
                stringBuilder.Append("&");
            }
            return stringBuilder.ToString();
        }

        #endregion



        #region Toast

        public IActionResult Toast(HttpContext httpContext, Toast message,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "toast");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");

            var content = new ContentResult()
            {
                Content = JsonSerializer.Serialize(message),
            };
            return content;

            //return Content(JsonSerializer.Serialize(message));
        }

        #endregion



        #region partial

        public IActionResult Partial(HttpContext httpContext, PartialViewResult partialView,bool responseResult = true )
        {
            httpContext.Response.Headers.Add("ResponseDataType", "partial");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            return partialView;
        }

        #endregion



        #region partial => toast

        public IActionResult PartialThenToast(HttpContext httpContext, PartialViewResult partialView, Toast message,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "partial-toast");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");

            message.SetToastOnResponse(httpContext.Response);
            return partialView;
        }
        //public IActionResult Partial(HttpContext httpContext, string name, object? model, Toast message)
        //{
        //    httpContext.Response.Headers.Add("ResponseDataType", "partial");
        //    message.SetToastOnResponse(httpContext.Response);
        //    return PartialView(name, model);
        //}
        //public IActionResult Partial(HttpContext httpContext, string name, object? model, Toast message, string targetElementId)
        //{
        //    httpContext.Response.Headers.Add("ResponseDataType", "partial");
        //    httpContext.Response.Headers.Add("targetElementId", targetElementId);
        //    message.SetToastOnResponse(httpContext.Response);
        //    return PartialView(name, model);
        //}

        #endregion



        #region toast => redirect

        public IActionResult ToastThenRedirect(HttpContext httpContext, string url, Toast message, bool replace,bool responseResult = true)
        {
            message.SetToastOnResponse(httpContext.Response);
            httpContext.Response.Headers.Add("ResponseDataType", "toast-redirect");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = url,
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() {Content = redirect.GetJsonStrng()};
            //return Content(redirect.GetJsonStrng());
        }
        public IActionResult ToastThenRedirect(HttpContext httpContext, string action, string controller, Toast message, bool replace,bool responseResult = true)
        {
            message.SetToastOnResponse(httpContext.Response);
            httpContext.Response.Headers.Add("ResponseDataType", "toast-redirect");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = GetUrl(action, controller),
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }
        public IActionResult ToastThenRedirect(HttpContext httpContext, string action, string controller, object routeValues,
            Toast message, bool replace,bool responseResult = true)
        {
            message.SetToastOnResponse(httpContext.Response);
            httpContext.Response.Headers.Add("ResponseDataType", "toast-redirect");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = GetUrl(action, controller, routeValues),
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }

        #endregion



        #region redirect => toast

        public IActionResult RedirectThenToast(HttpContext httpContext,ITempDataDictionary tempdata ,string url, Toast message, bool replace, bool responseResult = true)
        {
            tempdata["Toast"] = message.Serialize();
            httpContext.Response.Headers.Add("ResponseDataType", "redirect-toast");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = url,
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }
        public IActionResult RedirectThenToast(HttpContext httpContext,ITempDataDictionary tempdata ,string action, string controller, Toast message, bool replace, bool responseResult = true)
        {
            tempdata["Toast"] = message.Serialize();
            httpContext.Response.Headers.Add("ResponseDataType", "redirect-toast");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = GetUrl(action, controller),
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }
        public IActionResult RedirectThenToast(HttpContext httpContext,ITempDataDictionary tempdata ,string actionName, string controller, object routeValues,
            Toast message, bool replace,bool responseResult = true)
        {
            tempdata["Toast"] = message.Serialize();
            httpContext.Response.Headers.Add("ResponseDataType", "redirect-toast");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = GetUrl(actionName, controller, routeValues),
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }

        #endregion



        #region toast => refresh

        public IActionResult ToastThenRfresh(HttpContext httpContext, Toast message,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "toast-refresh");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            return new ContentResult() { Content = message.Serialize()};
            //return Content(message.Serialize());
        }

        #endregion



        #region json

        public IActionResult Json(HttpContext httpContext, object obj, bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "json");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            return new JsonResult(obj);
            //return Content(message.Serialize());
        }

        #endregion



        #region redirect

        public IActionResult Redirect(HttpContext httpContext, string url, bool replace,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "redirect");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = url,
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }
        public IActionResult Redirect(HttpContext httpContext,string action, string controller,bool replace,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "redirect");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            Redirect redirect = new Redirect()
            {
                Url = GetUrl(action, controller),
                IsReplace = replace,
                TimeOut = 0,
            };
            return new ContentResult() { Content = redirect.GetJsonStrng() };
            //return Content(redirect.GetJsonStrng());
        }

        #endregion




        public IActionResult Empty(HttpContext httpContext,bool responseResult = true)
        {
            httpContext.Response.Headers.Add("ResponseDataType", "empty");
            httpContext.Response.Headers.Add("ResponseResult", $"{responseResult}");
            return new StatusCodeResult(200);
        }


    }
}

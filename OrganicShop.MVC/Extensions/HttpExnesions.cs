using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Models;
using OrganicShop.Mvc;
using OrganicShop.Mvc.Areas.Admin;
using System.Diagnostics;
using System.Security.Claims;

namespace OrganicShop.Mvc.Extensions
{
    public static class HttpExnesions
    {
        public static ApplicationUser GetAppUser(this HttpContext httpContext)
        {
            ApplicationUser currentUser = new ApplicationUser()
            {
                Id = 1,
                UserName = "NULL",
                Email = "NULL",
                Role = null,
            };
            if (httpContext.User.Identity.IsAuthenticated)
            {

                if (httpContext.User != null)
                {
                    if (httpContext.User.Identity != null)
                    {
                        //currentUser.Id = long.Parse(httpContext.User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                        //currentUser.Username = httpContext.User.Identity.Name;
                        //currentUser.Role = Enum.Parse<Role>(httpContext.User.Claims.First(a => a.Type == ClaimTypes.Role).Value);
                        //Console.WriteLine($".......{currentUser.Username}...........");
                    }

                }
            }
            return currentUser;
        }


        public static ApplicationUser GetAppUser(this ClaimsPrincipal User)
        {
            ApplicationUser currentUser = new ApplicationUser()
            {
                Id = 1,
                UserName = "NULL",
                Email = "NULL",
                Role = null,
                PermissionIds = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 },
            };
            if (User != null)
            {
                if (User.Identity != null)
                {
                    //currentUser.Id = long.Parse(httpContext.User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                    //currentUser.Username = httpContext.User.Identity.Name;
                    //currentUser.Role = Enum.Parse<Role>(httpContext.User.Claims.First(a => a.Type == ClaimTypes.Role).Value);
                    //Console.WriteLine($".......{currentUser.Username}...........");
                }

            }
            return currentUser;
        }
    }
}

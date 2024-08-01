using Microsoft.AspNetCore.Http;
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
                Id = 0,
                UserName = "NULL",
                Email = "NULL",
                PhoneNumber = "NULL",
                Role = null,
            };
            if (httpContext.User != null)
            {
                if (httpContext.User.Identity != null)
                {
                    if (httpContext.User.Identity.IsAuthenticated)
                    {
                        currentUser = httpContext.User.GetAppUser();
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
                    if (User.Identity.IsAuthenticated)
                    {
                        currentUser.Id = long.Parse(User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value);
                        currentUser.UserName = User.Claims.First(a => a.Type == ClaimTypes.Name).Value;
                        currentUser.Email = User.Claims.First(a => a.Type == ClaimTypes.Email).Value;
                        currentUser.Role = Enum.Parse<Role>(User.Claims.First(a => a.Type == ClaimTypes.Role).Value);
                        Console.WriteLine($".......{currentUser.UserName}...........");
                    }
                }
            }
            return currentUser;
        }


    }
}

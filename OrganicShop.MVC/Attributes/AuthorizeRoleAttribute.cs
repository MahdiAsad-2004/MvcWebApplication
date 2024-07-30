using Microsoft.AspNetCore.Authorization;
using OrganicShop.Domain.Enums;

namespace OrganicShop.MVC.Attributes
{


    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        public AuthorizeRoleAttribute(params Role[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }



}

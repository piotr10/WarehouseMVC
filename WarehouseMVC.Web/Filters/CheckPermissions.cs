using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WarehouseMVC.Web.Filters
{
    public class CheckPermissions : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;
        public CheckPermissions(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUserPermision(context.HttpContext.User, _permission);

            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private bool CheckUserPermision(ClaimsPrincipal user, string permission)
        {
            //Połacz z bazą danych
            //Pobrać użytkownika
            //Sprawdzić czy ten użytkownik ma prawa dostępu do tej akcji
            return permission == "Read";
        }
    }
}
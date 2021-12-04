using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TavolgaAPI.Controllers;

namespace TavolgaAPI.Extensions
{
    public static class ControllerBaseExtension
    {
        public static string GetCurrentUserRole(this ControllerBase controller)
        {
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                throw new Exception("Identity пустой");
            return identity.FindFirst(ClaimsIdentity.DefaultRoleClaimType).Value;
        }

        public static int GetCurrentUserId(this ControllerBase controller)
        {
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                throw new Exception("Identity пустой");

            return Convert.ToInt32(identity.FindFirst("UserId").Value);
        }
    }
}

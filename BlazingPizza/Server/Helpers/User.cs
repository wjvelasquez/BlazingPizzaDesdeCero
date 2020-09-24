using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Helpers
{
    public static class User
    {
        
        public static string GetUserId(HttpContext context) => context.User.FindFirst(ClaimTypes.Name)?.Value;

        public static string GetUserEmail(HttpContext httpContext) => ClaimTypes.Email;
    }
}

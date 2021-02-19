﻿using System.Security.Claims;
using DSEU.Shared.Constants;

namespace DSEU.Shared.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static int UserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirst(p => p.Type == EmployeeClaimTypes.EmployeeId)?.Value!);
        }
        public static string IdentityUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

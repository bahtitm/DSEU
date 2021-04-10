using DSEU.Application.Common.Enums;
using System.Security.Claims;

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
            return int.Parse(principal.FindFirst(p => p.Type == UserClaimTypes.EmployeeId.ToString())?.Value!);
        }
        public static string IdentityUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirst(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

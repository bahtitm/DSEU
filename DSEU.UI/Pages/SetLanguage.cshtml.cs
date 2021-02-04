using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSEU.UI.Pages
{
    [AllowAnonymous]
    public class SetLanguageModel : PageModel
    {
        private const int CULTURE_COOKIE_LIFETIME_IN_YEARS = 10;
        public IActionResult OnGet(string culture,string returnUrl)
        {
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(CULTURE_COOKIE_LIFETIME_IN_YEARS) }
           );

            return LocalRedirect(returnUrl);
        }
    }
}
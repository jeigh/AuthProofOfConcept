using System.ComponentModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace AuthProofOfConcept.Mvc.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            // todo: display auth info
            return NotFound();
        }

        public IActionResult SelectAuthenticationSource()
        {
            return View();
        }

        public IActionResult FacebookSignIn()
        {
            return Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                FacebookDefaults.AuthenticationScheme);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SelectAuthenticationSource");
        }

        public IActionResult GoogleSignIn()
        {
            return Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                GoogleDefaults.AuthenticationScheme);
        }



    }
}

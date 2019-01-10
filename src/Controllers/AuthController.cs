using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Aiursoft.Blog.Models;
using Aiursoft.Blog.Data;
using Aiursoft.Pylon.Services;
using Aiursoft.Pylon.Attributes;
using System;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Models.ForApps.AddressModels;
using Aiursoft.Pylon;
using Aiursoft.Pylon.Models.Developer;

namespace Aiursoft.Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService<BlogUser> _authService;
        private readonly UserManager<BlogUser> _userManager;

        public AuthController(
            AuthService<BlogUser> authService,
            UserManager<BlogUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [AiurForceAuth(preferController: "", preferAction: "", justTry: false, register: false)]
        public IActionResult GoAuth()
        {
            return RedirectToAction("Index", "Home");
        }

        [AiurForceAuth(preferController: "", preferAction: "", justTry: false, register: true)]
        public IActionResult GoRegister()
        {
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AuthResult(AuthResultAddressModel model)
        {
            var user = await _authService.AuthApp(model);
            this.SetClientLang(user.PreferedLanguage);
            return Redirect(model.state);
        }
    }
}
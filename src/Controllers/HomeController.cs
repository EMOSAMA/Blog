﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aiursoft.Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Aiursoft.Pylon.Services;
using Aiursoft.Pylon;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Attributes;
using Aiursoft.Blog.Models.HomeViewModels;

namespace Aiursoft.Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<BlogUser> _signInManager;
        private readonly ILogger _logger;
        private readonly ServiceLocation _serviceLocation;

        public HomeController(
            SignInManager<BlogUser> signInManager,
            ILoggerFactory loggerFactory,
            ServiceLocation serviceLocation)
        {
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<HomeController>();
            _serviceLocation = serviceLocation;
        }

        [AiurForceAuth("", "", true)]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return this.SignOutRootServer(_serviceLocation.API, new AiurUrl(string.Empty, "Home", nameof(HomeController.Index), new { }));
        }
    }
}

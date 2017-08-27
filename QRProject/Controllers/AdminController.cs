using QRProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IInformationService _infoService;

        public AdminController(IInformationService infoService)
        {
            _infoService = infoService;
        }

        [Authorize(Roles = ("admin"))]
        public ActionResult AdminPage()
        {
            return View(_infoService.SetInformationViewModel(User.Identity.Name, string.Empty));
        }
    }
}
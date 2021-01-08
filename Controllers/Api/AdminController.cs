using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Connectify.Models;

namespace Connectify.Controllers.Api
{
    [Authorize(Roles = RoleName.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult UserRoleMap()
        {
            return View();
        }

        public ActionResult SupervisorEngineer()
        {
            return View();
        }
    }
}
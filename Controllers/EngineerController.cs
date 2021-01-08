using Connectify.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Connectify.Dto;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace Connectify.Controllers
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Engineer)]
    public class EngineerController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Engineer
        public ActionResult Index()
        {
            //get current user id and passing it to view
            var user = UserManager.FindById(User.Identity.GetUserId());
            EngineerDto dto = Mapper.Map<ApplicationUser, EngineerDto >(user);
            return View(dto);
        }
    }
}
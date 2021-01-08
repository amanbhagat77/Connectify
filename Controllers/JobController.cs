using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Connectify.Models;
using Connectify.Dto;
using Connectify.ViewModels;

namespace Connectify.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            return View("JobList");
        }

        public ActionResult Create()
        {
            var jobdto = new JobDto();
            return View("CreateJobForm", jobdto);
        }

        [Authorize(Roles = RoleName.Admin + "," + RoleName.Supervisor)]
        public ActionResult Allocate()
        {
            return View("AllocateEngineerForm");
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}

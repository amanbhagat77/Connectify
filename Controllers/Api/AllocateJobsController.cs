using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Connectify.Models;
using Connectify.Dto;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Connectify.Controllers.Api
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Supervisor)]
    public class AllocateJobsController : ApiController
    {
        private ApplicationDbContext _context;

        public AllocateJobsController()
        {
            _context = new ApplicationDbContext();
        }

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

        //Get: /api/allocatejobs
        public IHttpActionResult GetJobList()
        {
            var allocateEngineerDto = _context.Jobs
                .ToList()
                .Select(Mapper.Map<Job, AllocateEngineerDto>)
                .ToList();

            IList<EngineerDto> dto;

            //Get Current User
            var user = UserManager.FindById(User.Identity.GetUserId());
            //Chech if supervisor
            bool supervisorFlag = UserManager.GetRoles(user.Id).Contains(RoleName.Supervisor);
            
            //if current user is supervisor show engineersbysupervisor
            //else if user is admin show all the engineers
            if (supervisorFlag)
            {
                var EngineerIds = _context.SupervisorEngineers
                .Where(se => se.SupervisorId == user.Id)
                .Select(e => e.EngineerId)
                .ToList();

                var Engineers = new List<ApplicationUser>();
                foreach (var id in EngineerIds)
                {
                    Engineers.Add(UserManager.FindById(id));
                }
                dto = Engineers
                    .ToList()
                    .Select(Mapper.Map<ApplicationUser, EngineerDto>)
                    .ToList();

            }
            else
            {
                Engineer engineers = new Engineer();
                dto = engineers.getEngineerList()
                    .Select(Mapper.Map<ApplicationUser, EngineerDto>)
                    .OrderBy(e => e.UserName)
                    .ToList();
            }

            foreach (var ac in allocateEngineerDto)
            {
                ac.engineersDto = new List<EngineerDto>();
                ac.engineersDto.AddRange(dto);
                
            }

            return Ok(allocateEngineerDto);
        }

        //Post: /api/allocatejobs
        [HttpPut]
        public IHttpActionResult allocateEngineer(EngineerJobDto engjobdto)
        {

            var job = _context.Jobs.ToList().SingleOrDefault(j => j.Id == engjobdto.Id);
            if (job == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            if (job.EngineerId == engjobdto.EngineerId)
                return BadRequest();

            job.Engineer = _context.Users.SingleOrDefault(u => u.Id == engjobdto.EngineerId);
            job.EngineerId = engjobdto.EngineerId;
            job.Status = JobStatus.Allocated;
            job.Description = job.Engineer.UserName + " has been allocated for this Job";
            _context.SaveChanges();

            return Ok();
        }


    }
}

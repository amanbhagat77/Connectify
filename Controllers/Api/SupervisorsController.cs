using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Connectify.Models;
using Microsoft.AspNet.Identity;
using AutoMapper;
using Connectify.Dto;

namespace Connectify.Controllers.Api
{
    [Authorize(Roles = RoleName.Admin)]
    public class SupervisorsController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public SupervisorsController()
        {

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

        //GET: /api/Supervisors

        public IHttpActionResult getSupervisors()
        {
            var roles = _context.Roles
                .ToList()
                .Single(r => r.Name == RoleName.Supervisor)
                .Users.ToList();
            var SupervisorIds = roles.Select(e => e.UserId);

            var supervisors = new List<ApplicationUser>();
            foreach(var id in SupervisorIds)
            {
                supervisors.Add(UserManager.FindById(id));
            }

            return Ok(supervisors);
        }


        //GET: /api/supervisors/id
        public List<EngineerDto> getEngineersbySupervisorId(string supervisorId)
        {
            var EngineerIds = _context.SupervisorEngineers
                .Where(se => se.SupervisorId == supervisorId)
                .Select(e => e.EngineerId)
                .ToList();

            var Engineers = new List<ApplicationUser>();
            foreach (var id in EngineerIds)
            {
                Engineers.Add(UserManager.FindById(id));
            }
            var engineerDto = Engineers
                .ToList()
                .Select(Mapper.Map<ApplicationUser, EngineerDto>)
                .ToList();
            return engineerDto;
        }


        //POST: /api/supervisors/SuperVisorEngineerDto
        [HttpPost]
        public IHttpActionResult MapSuperVisors(SupervisorEngineersDto supEngDto)
        {
            var supervisorEngineersInDB = _context.SupervisorEngineers.ToList();
            if(supEngDto == null || supEngDto.EngineerIds == null)
            {
                return BadRequest();
            }

            //mapping engineer to supervisor only iff that engineer is not already present in the database tagged to another supervisor.
            foreach(var engineerId in supEngDto.EngineerIds)
            {
                if(supervisorEngineersInDB.Where(se => se.EngineerId == engineerId).Count() == 0)
                {
                    var supervisorEngineersObj = new SupervisorEngineers()
                    {
                        EngineerId = engineerId,
                        SupervisorId = supEngDto.SupervisorId
                    };
                    _context.SupervisorEngineers.Add(supervisorEngineersObj);
                    var user = _context.Users.SingleOrDefault(u => u.Id == engineerId);
                    user.Mapped = true;
                }
                else
                {
                    return BadRequest();
                }
                
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}

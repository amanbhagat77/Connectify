using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Connectify.Models;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Connectify.Dto;

namespace Connectify.Controllers.Api
{
    [Authorize(Roles = RoleName.Admin)]
    public class AdminUserRoleController : ApiController
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


        //GET: /api/AdminUserRole
        public IHttpActionResult GetUserList()
        {

            var rolestore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(rolestore);

            var users = UserManager.Users.ToList();
            var roles = roleManager.Roles.Select(r => new { r.Id, r.Name}).ToList();

            List<UserRoleViewModel> userRoles = new List<UserRoleViewModel>(); 
            
            foreach(var user in users)
            {
                UserRoleViewModel userRoleDto = new UserRoleViewModel();
                userRoleDto.UserName = user.UserName;
                userRoleDto.UserId = user.Id;
                userRoleDto.Email = user.Email;
                userRoleDto.PhoneNumber = user.PhoneNumber;
                userRoleDto.AssignedRoles = new List<string>();
                userRoleDto.AssignedRoles.AddRange(UserManager.GetRoles(user.Id));    
                userRoleDto.Roles = new List<Object>();
                userRoleDto.Roles.AddRange(roles);
                userRoles.Add(userRoleDto);
            }

            return Ok(userRoles);
        }

        //Put: /api/adminuserrole/
        [HttpPut]
        public IHttpActionResult allocateEngineer(UserRoleDto userRoleDto)
        {

            var role = _context.Roles.SingleOrDefault(r => r.Id == userRoleDto.RoleId);
            var user = UserManager.FindById(userRoleDto.UserId);
            var userRoles = UserManager.GetRoles(user.Id);
            if (userRoles.Contains(role.Name))
            {
                return BadRequest();
            }
            else
            {
                UserManager.AddToRole(user.Id, role.Name);
                _context.SaveChanges();

            }
            return Ok();
        }

    }
}

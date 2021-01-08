using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Connectify.Dto;

namespace Connectify.Models
{
    public class Engineer
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public Engineer()
        {
            _context = new ApplicationDbContext();
        }

        //Return list of Application User whose role is Engineer
        public IList<ApplicationUser> getEngineerList()
        {
            var engineerDto = new EngineerDto();
            var roles = _context.Roles
                .ToList()
                .Single(r => r.Name == RoleName.Engineer)
                .Users.ToList();
            var EngineersIds = roles.Select(e => e.UserId);

            IList<ApplicationUser> engineers = new List<ApplicationUser>();
            IList<EngineerDto> engineersdto = new List<EngineerDto>();

            foreach (var id in EngineersIds)
            {
                engineers.Add(_context.Users.SingleOrDefault(e => e.Id == id));
            }

            return engineers.ToList();

        }
    }
}
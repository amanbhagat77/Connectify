using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Connectify.Models;
using Connectify.Dto;
using System.Data.Entity;
using AutoMapper;

namespace Connectify.Controllers.Api
{
    [Authorize(Roles = RoleName.Admin + "," + RoleName.Engineer)]
    public class EngineersController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Get /api/engineers/
        public IHttpActionResult getUnMappedEngineerList()
        {
            Engineer engineersdto = new Engineer();
            var engineerlistDto = engineersdto.getEngineerList()
                .Where(e => e.Mapped == false)
                .OrderBy(e => e.UserName)
                .Select(Mapper.Map<ApplicationUser, EngineerDto>);


            return Ok(engineerlistDto);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Connectify.Models;
using Connectify.Dto;

namespace Connectify.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Job, JobDto>();
            Mapper.CreateMap<Job, AllocateEngineerDto>();
            Mapper.CreateMap<ApplicationUser, EngineerDto>();

            //Dto to Domain
            Mapper.CreateMap<JobDto, Job>();
            Mapper.CreateMap<AllocateEngineerDto, Job>();
            Mapper.CreateMap<EngineerDto, ApplicationUser>();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Connectify.Models;

namespace Connectify.Dto
{
    public class SupervisorEngineersDto
    {
        public string SupervisorId { get; set; }
        public List<String> EngineerIds { get; set; }
    }
}
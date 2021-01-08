using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Connectify.Models;

namespace Connectify.Models
{
    public class SupervisorEngineers
    {
        public int id { get; set; }
        [Required]
        public string SupervisorId { get; set; }

        [Required]
        public string EngineerId { get; set; }

    }
}
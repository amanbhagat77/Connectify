using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connectify.Dto
{
    public class AcceptJobDto
    {
        public int JobId { get; set; }
        public bool IsAccepted { get; set;  }
        public string Description { get; set; }
    }
}
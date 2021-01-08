using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connectify.Models
{
    public class JobActivity
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string EngineerId { get; set; }

        public Job Job { get; set; }
        public ApplicationUser Engineer { get; set; }
    }
}
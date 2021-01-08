using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connectify.Models
{
    public class JobStatus
    {
        public const string Created = "Created";
        public const string Allocated = "Allocated";
        public const string Accepted = "Accepted";
        public const string OnSite = "OnSite";
        public const string Completed = "Completed";
        public const string Onhold = "Onhold";
        public const string Rejected = "Rejected";
    }
}
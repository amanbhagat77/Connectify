using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Connectify.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Connectify.Dto
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<String> AssignedRoles { get; set; }

        public List<Object> Roles { get; set; }

    }
}
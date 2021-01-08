using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Connectify.Models;
using System.ComponentModel.DataAnnotations;

namespace Connectify.Dto
{
    public class JobDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string State { get; set; }

        [Required]
        [StringLength(255)]
        public string JobItem { get; set; }

        [Required]
        [StringLength(255)]
        public string JobType { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public DateTime? PreferedDateTime { get; set; }
        public DateTime? DateCreated { get; set; }

        public ApplicationUser Engineer { get; set; }

    }
}
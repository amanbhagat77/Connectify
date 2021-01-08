using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Connectify.Dto
{
    public class AllocateEngineerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public string Status { get; set; }

        public string EngineerId { get; set; }

        public string Description { get; set; }

        public List<EngineerDto> engineersDto { get; set; }

        public AllocateEngineerDto()
        {
            new List<EngineerDto>();
        }

        

    }
}
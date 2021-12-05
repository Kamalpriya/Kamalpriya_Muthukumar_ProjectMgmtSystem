using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    // 1. Project model
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Detail { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}

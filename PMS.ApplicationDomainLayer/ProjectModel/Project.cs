using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.ApplicationDomainLayer.ProjectModel
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Detail { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}

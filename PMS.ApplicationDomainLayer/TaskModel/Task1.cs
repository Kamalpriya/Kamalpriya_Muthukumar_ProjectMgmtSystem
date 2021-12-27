using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.ApplicationDomainLayer.TaskModel
{
    [Table("Task1")]
    public class Task1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int AssignedToUserId { get; set; }

        public string Detail { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.TaskModel
{
    // 1. Task model (Sprint I)
    public class Task
    {
        [Required]
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

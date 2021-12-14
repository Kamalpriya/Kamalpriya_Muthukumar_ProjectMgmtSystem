using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models
{
    // 4. User Login Model (Sprint I)
    [Table("UserLogin")]
    public class UserLogin
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

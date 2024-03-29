﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.UserModel
{
    // 1. User model (Sprint I)
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

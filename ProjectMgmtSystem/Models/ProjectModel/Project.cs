﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem.Models.ProjectModel
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
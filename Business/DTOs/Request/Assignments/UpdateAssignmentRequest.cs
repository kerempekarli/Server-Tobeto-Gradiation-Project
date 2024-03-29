﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.CoursesFolder;

namespace Business.DTOs.Request.Assignments
{
    public class UpdateAssignmentRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? IsSend { get; set; }
    }
}

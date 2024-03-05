﻿using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Exam
{
    public class UpdateExamRequest
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string? Type { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int QuestionAmount { get; set; }
        public TimeSpan? ExamDuration { get; set; }
    }

}

﻿using System.Security.AccessControl;
using Core.Entities;

namespace Entities.Concretes.CoursesFolder
{
    public class Question : Entity<int>
    {
        public int ExamId { get; set; }
        public string? Problem { get; set; }
        public Exam Exam { get; set; }
        public List<Option> Options { get; set; }

    }
}
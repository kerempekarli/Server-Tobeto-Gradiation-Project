﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Profiles
{
    public class Skill : Entity<int>
    {
        public string? Name { get; set; }
        public List<StudentSkill>? StudentSkills { get; set; }
    }
}

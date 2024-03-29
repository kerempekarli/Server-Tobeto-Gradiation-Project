﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfInstructorCourseDal : EfRepositoryBase<InstructorCourse, int, TobetoContext>, IInstructorCourseDal
    {
        public EfInstructorCourseDal(TobetoContext context) : base(context)
        {
        }
    }

}

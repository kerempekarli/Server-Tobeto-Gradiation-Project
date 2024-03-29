﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfLessonDal : EfRepositoryBase<Lesson, int, TobetoContext>, ILessonDal
    {
        public EfLessonDal(TobetoContext context) : base(context)
        {
        }
    }

}

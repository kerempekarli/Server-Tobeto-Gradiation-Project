﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfQuestionDal : EfRepositoryBase<Question, int, TobetoContext>, IQuestionDal
    {
        public EfQuestionDal(TobetoContext context) : base(context)
        {
        }
    }

}

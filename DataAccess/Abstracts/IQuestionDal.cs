﻿using Core.DataAccess.Repositories;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Abstracts
{
    public interface IQuestionDal : IRepository<Question, int>, IAsyncRepository<Question, int>
    {
        // Question'a özgü metodlar buraya eklenebilir.
    }



}
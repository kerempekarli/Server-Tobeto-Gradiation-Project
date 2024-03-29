﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfSoftwareLanguageDal : EfRepositoryBase<SoftwareLanguage, int, TobetoContext>, ISoftwareLanguageDal
    {
        public EfSoftwareLanguageDal(TobetoContext context) : base(context)
        {
        }
    }

}

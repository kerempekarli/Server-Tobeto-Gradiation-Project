﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Concretes.CoursesFolder;

namespace DataAccess.Concretes
{
    public class EfPaymentDal : EfRepositoryBase<Payment, int, TobetoContext>, IPaymentDal
    {
        public EfPaymentDal(TobetoContext context) : base(context)
        {
        }
    }

}

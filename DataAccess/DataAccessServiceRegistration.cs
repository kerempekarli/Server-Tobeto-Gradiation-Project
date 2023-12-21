﻿using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TobetoContext>(options => options.UseSqlServer(configuration.GetConnectionString("Tobeto")));

            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IUserDal,EfUserDal>();
            services.AddScoped<IExamDal, EfExamDal>();
            services.AddScoped<IStudentDal, EfStudentDal>();
            services.AddScoped<IInstructorDal, EfInstructorDal>();
            services.AddScoped<IMediaPostDal, EfMediaPostDal>();
            services.AddScoped<IBlogDal, EfBlogDal>();
            services.AddScoped<ISurveyDal, EfSurveyDal>();
            services.AddScoped<ISubjectDal, EfSubjectDal>();
            services.AddScoped<IPaymentDal, EfPaymentDal>();
            services.AddScoped<IManagerDal, EfManagerDal>();
            services.AddScoped<ICertificateDal, EfCertificateDal>();
            services.AddScoped<ILanguageDal, EfLanguageDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<ILanguageLevelDal, EfLanguageLevelDal>();
            services.AddScoped<IAssignmentDal, EfAssignmentDal>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IStudentSkillDal, EfStudentSkillDal>();
            services.AddScoped<IUserRoleDal, EfUserRoleDal>();
            services.AddScoped<ICourseSubjectDal, EfCourseSubjectDal>();
            services.AddScoped<ISkillDal, EfSkillDal>();
            services.AddScoped<IInstructorCourseDal, EfInstructorCourseDal>();
            services.AddScoped<ICourseStatusDal, EfCourseStatusDal>();
            services.AddScoped<ISocialMediaAccountDal, EfSocialMediaAccountDal>();
            services.AddScoped<IApplicationDal, EfApplicationDal>();



            return services;
        }
    }
}

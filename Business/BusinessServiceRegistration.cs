﻿using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IApplicantService, ApplicantManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            return services;
        }
    }
}

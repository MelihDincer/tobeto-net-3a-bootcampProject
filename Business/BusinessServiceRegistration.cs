using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IApplicantService, ApplicantManager>();
            //services.AddScoped<IEmployeeService, EmployeeManager>();
            //services.AddScoped<IInstructorService, InstructorManager>();
            //services.AddScoped<IApplicationService, ApplicationManager>();
            //services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            //services.AddScoped<IBootcampService, BootcampManager>();
            //services.AddScoped<IBootcampStateService, BootcampStateManager>();
            //services.AddScoped<IBlackListService, BlackListManager>();

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
            services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.ServiceType.Name.EndsWith("Manager"));
            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly,
            Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (Type? item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }

        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
            foreach (Type? type in types)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface, type);
                }
            }
            return services;
        }
    }
}

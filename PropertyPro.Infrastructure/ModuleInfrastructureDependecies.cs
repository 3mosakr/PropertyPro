using Microsoft.Extensions.DependencyInjection;
using PropertyPro.Infrastructure.Reposatories.Abstraction;
using PropertyPro.Infrastructure.Reposatories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyPro.Infrastructure
{
    public static class ModuleInfrastructureDependecies
    {
        public static IServiceCollection AddInfrastructureDependecies(this IServiceCollection services)
        {
            //services.AddTransient<IStudentRepository, StudentRepository>();
            //services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            //services.AddTransient<IInstructorRepository, InstructorRepository>();
            //services.AddTransient<ISubjectRepository, SubjectRepository>();
            //services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
 
            return services;
        }

    }
}

using E2E.Employee.Application.Context;
using E2E.Employee.Application.Employees;
using E2E.Employee.Application.Genders;
using E2E.Employee.Application.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2E.Employee.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IGenderService, GenderService>();

            services.AddDbContext<E2EDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("E2EDb"));
            });

            return services;
        }
    }
}

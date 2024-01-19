using E2E.Employee.Application.Genders;
using E2E.Employee.Application.Persistence;
using E2E.Employee.Application.Persons;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(CultureInfo.InvariantCulture);
                options.SupportedCultures = new List<CultureInfo> { CultureInfo.InvariantCulture };
                options.SupportedUICultures = new List<CultureInfo> { CultureInfo.InvariantCulture };
            });


            return services;
        }
    }
}

using KnowIt.Domain.Mappings;
using KnowIt.Service.EventDetailServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowIt.Service
{
   public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependenciesServices(this IServiceCollection services)
        {
            services.ConfigureInjection();
            return services;
        }
            public static void ConfigureInjection(this IServiceCollection services)
        {
            services.AddTransient<IEventDetailService, EventDetailService>();
            services.AddAutoMapper(c => c.AddProfile<DtoToModelProfile>());
        }
       
    }
}

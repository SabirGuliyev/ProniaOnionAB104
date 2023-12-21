using Microsoft.Extensions.DependencyInjection;
using ProniaOnion104.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion104.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            //service.AddAutoMapper(typeof(CategoryProfile));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return service;

        }
    }
}

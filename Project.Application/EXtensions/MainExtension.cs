using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.EXtensions
{
    public static class MainExtension
    {
        public static void AddMainExtension(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddApplicationServices();
        }
    }
}

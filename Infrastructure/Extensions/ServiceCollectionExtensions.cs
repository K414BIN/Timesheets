using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Timesheets.Data;
using Timesheets.Data.Implementetion;
using Timesheets.Data.Interfaces;
using Timesheets.Services.Implementetion;
using Timesheets.Services.Interfaces;

namespace Timesheets.Infrastructure.Extensions
{
    /// <summary>
    /// Создание специального внутреннего класса для хранения связей и прочего. Служит для разгрузки Startup.cs и улучшения читаемости кода
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
       /// <summary>
       /// Помещаем в отдельный класс способ миграции базы данных.  
       /// IConfiguration configuration - здесь это входящиий параметр! Не забыть!!!
       /// </summary>
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
               services.AddDbContext<TimeSheetDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),tabl => tabl.MigrationsAssembly("Timesheets")));
        }

        /// <summary>
        /// Создание класса для конфигурации репозиториев
        /// </summary>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ISheetRepo, SheetRepo>();
        }

        
        /// <summary>
        /// Создание класса для конфигурации менеджеров. У меня Services вместо Domain. В дальнейшем надо будет избегать названия Services - это вносит путаницу 
        /// </summary>
        public static void ConfigureServicesManagers(this IServiceCollection services)
        {
            services.AddScoped<ISheetManager, SheetManager>();     
        }
        
        /// <summary>
        /// Создание отдельного класса для конфигурации Swagger`a, потому что в этом пакете много настроек
        /// </summary>
        public static void ConfigureBackendSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Timesheets", Version = "v1"  });
            });
        }
    }
}

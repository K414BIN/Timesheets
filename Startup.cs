using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Timesheets.Data.Implementetion;
using Timesheets.Data.Interfaces;
using Timesheets.Services.Implementetion;
using Timesheets.Services.Interfaces;
using Timesheets.Data;
using Microsoft.EntityFrameworkCore;

namespace Timesheets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          // services.AddDbContext<TimeSheetDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TimeSheetDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),tabl => tabl.MigrationsAssembly("Timesheets")));
            services.AddScoped<ISheetRepo, SheetRepo>();
            services.AddScoped<ISheetManager, SheetManager>();
     //       services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IContractRepo, ContractRepo>();
            services.AddControllers();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Timesheets", Version = "v1"  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                 app.UseSwagger(c =>
               {
                c.SerializeAsV2 = true;
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Timesheets v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WebApiStudent_Net_Core2.Extensions;
using WebApiStudent_Net_Core2.Data;
using Microsoft.EntityFrameworkCore;
using WebApiStudent_Net_Core2.Models.DataManager;
using WebApiStudent_Net_Core2.Interfaces;
using WebApiStudent_Net_Core2.Models;

namespace WebApiStudent_Net_Core2
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
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.ConfigureSqlContext(Configuration);
            //services.AddDbContext<DatabaseContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddScoped<IDataRepository<Course>, CourseManager>();
            services.AddScoped<IDataRepository<LogData>, LogDataManager>();
            services.AddScoped<IDataRepository<UserInfo>, UserInfoManager>();

            services.ConfigureRepositoryWrapper();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

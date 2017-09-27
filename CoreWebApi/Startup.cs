using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebApi.entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.ResponseCaching;


namespace CoreWebApi
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
            
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.CookieName = ".MyApp.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.HttpOnly = true;
            });
            services.AddMvc();
            /*services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();*/
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));     
          
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TestDBContext>(options =>
                options.UseSqlServer(connection));
            services.AddMvc(config =>
            {
                foreach (var formatter in config.InputFormatters)
                {
                    if (formatter.GetType() == typeof(JsonInputFormatter))
                        ((JsonInputFormatter)formatter).SupportedMediaTypes.Add(
                            MediaTypeHeaderValue.Parse("text/plain"));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseCors("AllowAll");
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home2}/{action=Index}/{id?}");
                }
            );
        }
    }
}
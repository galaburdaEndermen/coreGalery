using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using coreGalery.Models;
using Microsoft.EntityFrameworkCore;

namespace coreGalery
{
    public class Startup
    {
        public IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the conner.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //string connection = configur.GetConnectionString("DefaultConnection");

            services.AddDbContext<GaleryDbContext>(options =>
                options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IPaintingRepo, EFPaintingRepo>();
            services.AddMvc((options) => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
           
        }
    }
}

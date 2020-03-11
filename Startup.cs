using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code360_Management.Models;
using Code360_Management.Models.Batchs;
using Code360_Management.Models.Employment;
using Code360_Management.Models.Guarantors;
using Code360_Management.Models.Programs;
using Code360_Management.Models.Projects;
using Code360_Management.Models.Students;
using Code360_Management.Models.Students_In_Batch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Code360_Management
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("StudentDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDbContext>();
            
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddScoped<IStudents, SQLMockStudents>();
            services.AddScoped<IGuarantor, SQLGuarantorRepository>();
            services.AddScoped<IBatch, SQLBatchRepo>();
            services.AddScoped<IProgram, SQLProgramRepo>();
            services.AddScoped<IStudentBatch, SQLStudentBatchRepo>();
            services.AddScoped<IProject, SQLProjectRepo>();
            services.AddScoped<ICompany, SQLCompanyRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();


            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Welcome to Code360");
            //    });
            //});
        }
    }
}

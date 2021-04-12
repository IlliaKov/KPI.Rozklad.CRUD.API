using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rozklad.CRUD.BLL.Services.Implementations;
using Rozklad.CRUD.BLL.Services.Interfaces;
using Rozklad.CRUD.DAL.Repositories;
using Rozklad.CRUD.DAL.Repositories.Implementations;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPI.Rozklad.CRUD.API
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RozkladContext>(options =>
                    options.UseSqlServer(connection, p => { p.EnableRetryOnFailure(); p.MigrationsAssembly("Rozklad.CRUD.DAL"); }));

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddTransient<IEvaluationRepository, EvaluationRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserClassRepository, UserClassRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();

            services.AddTransient<IEvaluationService, EvaluationService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserClassService, UserClassService>();
            services.AddTransient<IScheduleService, ScheduleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

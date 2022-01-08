using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Portal.Core.Common;
using Tahaluf.Portal.Core.Repository;
using Tahaluf.Portal.Core.Repositry;
using Tahaluf.Portal.Core.Services;
using Tahaluf.Portal.Infra.Common;
using Tahaluf.Portal.Infra.Repository;
using Tahaluf.Portal.Infra.Repositry;
using Tahaluf.Portal.Infra.Services;

namespace Tahaluf.Portal.Api
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
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]")),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });
            services.AddScoped<IDBContext,DBContext>();
            services.AddScoped<ICourseRepositry, CourseRepositry>();
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<ITeacher_CourseRepository, Teacher_CourseRepository>();
            services.AddScoped<ITeacher_CourseService, Teacher_CourseService>();

            services.AddScoped<IJwtUserAuthService, JwtUserAuthService>();
            services.AddScoped<IJwtUserAuthRepository, JwtUserAuthRepository>();

            services.AddScoped<IMARKStService, MARKSService>();
            services.AddScoped<IMARKSRepository, MARKSRepository>();
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

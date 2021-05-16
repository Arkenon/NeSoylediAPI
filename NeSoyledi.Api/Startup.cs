using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NeSoyledi.Api.MiddleWares;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Business.Concrete;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Data.Concrete;
using System;
using System.Text;

namespace NeSoyledi.Api
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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });       
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDiscourseRepository, DiscourseRepository>();
            services.AddScoped<IDiscourseService, DiscourseManager>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IProfileService, ProfileManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManager>();
            services.AddDbContext<NeSoylediDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ne Söyledi?", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseRouting();

            app.UseCors(
               options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
           );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<SwaggerInterceptor>();

            app.UseSwagger(); app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json?key=9a92661b70c983be53143d7600bc2284", "Ne Söyledi? V1");
            });
        }
    }
}

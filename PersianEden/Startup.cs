using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PersianEden.Config;
using PersianEden.DataLayer;
using PersianEden.Infrastructure.Services;
using PersianEden.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersianEden
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });

            services.AddHttpClient("AccountClient", c => //Named Http Client
            {
                c.DefaultRequestHeaders.Add("X-Custom-Env", "TEST");
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false);


            services.AddSwaggerGen(setup =>
            {
                services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
                setup.OperationFilter<CustomHeader>();

            });





            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration.GetValue<string>("Jwt:Issuer"),
                        ValidAudience = Configuration.GetValue<string>("Jwt:Audience"),
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Jwt:Secret"))),
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });



            services.AddHttpContextAccessor();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            MiddlewareConfiguration.ConfigureEf(services, Configuration.GetConnectionString("DataConnection"));
            MiddlewareConfiguration.ConfigureUow(services);
            MiddlewareConfiguration.ConfigureManager(services);
            MiddlewareConfiguration.ConfigureRepository(services);
            MiddlewareConfiguration.ConfigureServices(services);



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage()
            );

            services.AddHangfireServer();

            services.AddSignalR();
            services.AddScoped<IEmailService, EmailService>();//27-7


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
                    // c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versioned API v1.0");
                    // c.DocExpansion("none");
                    c.DocumentTitle = "PersianEden";
                    c.DocExpansion(DocExpansion.None);
                });
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });


            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
                c.DocumentTitle = "Title Documentation";
                c.DocExpansion(DocExpansion.None);
            });
            app.UseAuthentication();
            app.UseMvc();


            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Developed-By", "Your Name");
                await next.Invoke();
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(
                headerName, new string[] { "ResultExecutingSuccessfully" });
        }
    }
}


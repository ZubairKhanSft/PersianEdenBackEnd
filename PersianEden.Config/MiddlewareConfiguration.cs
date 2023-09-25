
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersianEden.DataLayer;
using PersianEden.DataLayer.Repositories;
using PersianEden.Infrastructure.DataLayer;
using PersianEden.Infrastructure.Managers;
using PersianEden.Infrastructure.Repositrories;
using PersianEden.Infrastructure.Services;
using PersianEden.Manager;
using PersianEden.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianEden.Config
{
    public class MiddlewareConfiguration
    {
        public static void ConfigureEf(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

        }
        public static void ConfigureUow(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureManager(IServiceCollection services)
        {
            services.AddScoped<INameManager, NameManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IDeceasedPersonManager, DeceasedPersonManager>();
        }
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<INameRepository, NameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDeceasedPersonRepository, DeceasedPersonRepository>();
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}


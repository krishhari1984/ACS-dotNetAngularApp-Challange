using ACS_dotNetAngularApp.Business.Abstractions;
using ACS_dotNetAngularApp.Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS_dotNetAngularApp.Business
{
    public static class BusinessExtenssions
    {
            
        public static IServiceCollection AddUserServiceExtenssions(this IServiceCollection services, IConfiguration _configuration)
        {
            var connStr = _configuration["ConnectionsString:SQLConnection"];
            services.AddTransient<IContactUser, UserService>();
            services.AddDbContext<UsersContext>(opts =>
            opts.UseSqlServer(connStr));
            return services;
        }
    }
}

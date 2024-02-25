using Black_swan.Infrastructure.Mail;
using Black_Swan_Application.Contracts.Infrastructure;
using Black_Swan_Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Black_swan.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection ConfigureStructureServices(this IServiceCollection services,
        IConfiguration configuration)
        {

            //services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }

    }
}



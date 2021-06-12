using MED.Auth.API.Application.Messages.Commands.UserCommand;
using MED.Auth.API.Application.Messages.ConsumersBus;
using MED.Auth.Domain.Entities;
using MED.Auth.Domain.Repositories;
using MED.Auth.Infrastructure.Data;
using MED.Auth.Infrastructure.Data.Repositories;
using MED.Core.Extensions;
using MED.Core.Mediator;
using MED.Core.MessageBus;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MED.Auth.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            // Usando com banco de dados em memória
            // services.AddDbContext<AuthDbContext>(options => options.UseInMemoryDatabase("MinhaEscolaDigitalServices"));
            // Usando com SqlServer
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServerCs")));

            services.AddIdentity<UserModel, IdentityRole>(options =>
                {
                    // Configurações de senha
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 2;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddErrorDescriber<IdentityPortugues>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IMessageBusHandler, MessageBusHandler>();

            services.AddSingleton<ICreateUserGuardianConsumer, CreateUserGuardianConsumer>();

            services.AddMediatR(typeof(AddUserCommand));
        }

        public static IApplicationBuilder UseDependencyConfiguration(this IApplicationBuilder app)
        {

            // Registra o serviço
            var bus = app.ApplicationServices.GetRequiredService<ICreateUserGuardianConsumer>();
            bus.RegisterConsumer();

            return app;
        }

    }
}
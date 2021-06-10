
using MED.Core.Extensions;
using MED.Core.Mediator;
using MED.Core.MessageBus;
using MED.Identidade.API.Application.Messages.Commands.UsuarioCommand;
using MED.Identidade.API.Application.Messages.ConsumersBus;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using MED.Identidade.Infrastructure.Data;
using MED.Identidade.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MED.Identidade.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            // Usando com banco de dados em memória
            //services.AddDbContext<IdentidadeDbContext>(options => options.UseInMemoryDatabase("MinhaEscolaDigitalMonolito"));
            // Usando com SqlServer
            services.AddDbContext<IdentidadeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServerCs")));

            services.AddIdentity<UsuarioModel, IdentityRole>(options =>
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
                .AddEntityFrameworkStores<IdentidadeDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IMessageBusHandler, MessageBusHandler>();

            services.AddSingleton<IRegistarUsuarioResponsavelConsumer, RegistarUsuarioResponsavelConsumer>();

            services.AddMediatR(typeof(AdicionarUsuarioCommand));
        }

        public static IApplicationBuilder UseDependencyConfiguration(this IApplicationBuilder app)
        {

            // Registra o serviço
            var bus = app.ApplicationServices.GetRequiredService<IRegistarUsuarioResponsavelConsumer>();
            bus.RegistrarConsumer();

            return app;
        }

    }
}
using MED.Aluno.API.Application.Messages.Commands.AlunoCommand;
using MED.Aluno.Domain.Repositories;
using MED.Aluno.Infrastructure.Data;
using MED.Aluno.Infrastructure.Data.Repositories;
using MED.Core.Mediator;
using MED.Core.MessageBus;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MED.Aluno.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            // Usando com SqlServer
            services.AddDbContext<AlunoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServerCs")));
            // Usando com banco de dados em memória
            //services.AddDbContext<AlunoDbContext>(options => options.UseInMemoryDatabase("MinhaEscolaDigitalMonolito"));

            services.AddScoped<IAlunoRepository, AlunoRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IMessageBusHandler, MessageBusHandler>();

            // services.AddScoped<IRequestHandler<AdicionarAlunoCommand, ValidationResult>, AlunoCommandHandler>();
            // services.AddScoped<IRequestHandler<AlterarEnderecoAlunoCommand, ValidationResult>, AlunoCommandHandler>();
            services.AddMediatR(typeof(AdicionarAlunoCommand));
        }
    }
}
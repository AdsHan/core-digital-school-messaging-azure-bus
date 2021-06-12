using MED.Core.Mediator;
using MED.Core.MessageBus;
using MED.Student.API.Application.Messages.Commands.StudentCommand;
using MED.Student.Domain.Repositories;
using MED.Student.Infrastructure.Data;
using MED.Student.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MED.Student.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            // Usando com SqlServer
            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLServerCs")));
            // Usando com banco de dados em memória
            // services.AddDbContext<StudentDbContext>(options => options.UseInMemoryDatabase("MinhaEscolaDigitalServices"));

            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IMessageBusHandler, MessageBusHandler>();

            // services.AddScoped<IRequestHandler<AddStudentCommand, ValidationResult>, StudentCommandHandler>();
            // services.AddScoped<IRequestHandler<AddStudentCommand, ValidationResult>, StudentCommandHandler>();
            services.AddMediatR(typeof(AddStudentCommand));
        }
    }
}
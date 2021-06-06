using MED.Core.Commands;
using MED.Core.Communication;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Usuario.API.Application.Messages.Commands.UsuarioCommand
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<AdicionarUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResult> Handle(AdicionarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var usuarioExistente = await _usuarioRepository.ObterPorUserNameAsync(command.Email);

            if (usuarioExistente != null)
            {
                AdicionarErro("Este usuário já está em uso por outra pessoa!");
                return BaseResult;
            }

            var usuario = new UsuarioModel()
            {
                UserName = command.Email,
                Email = command.Email,
                EmailConfirmed = true
            };

            var result = await _usuarioRepository.CriarAsync(usuario, command.Senha);

            if (result.Succeeded)
            {

            }

            return BaseResult;
        }

    }
}
using MED.Core.Commands;
using MED.Core.Communication;
using MED.Identidade.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Identidade.API.Application.Messages.Commands.TokenCommand
{
    public class TokenCommandHandler : CommandHandler,
        IRequestHandler<AtualizarTokenCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenRepository _tokenRepository;

        public TokenCommandHandler(IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository)
        {
            _usuarioRepository = usuarioRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<BaseResult> Handle(AtualizarTokenCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var usuarioExistente = await _usuarioRepository.ObterPorUserNameAsync(command.Email);

            if (usuarioExistente == null)
            {
                AdicionarErro("Não foi possível localizar o usuário!");
                return BaseResult;
            }

            var result = await _usuarioRepository.VerificaSenhaAsync(usuarioExistente, command.Senha);

            if (result.Succeeded)
            {

                var novoToken = await _tokenRepository.AtualizarToken(command.Token);

                if (novoToken == null)
                {
                    AdicionarErro("O Token ainda está válido!");
                    return BaseResult;

                }
                BaseResult.response = novoToken;
                return BaseResult;

            }
            AdicionarErro("Usuário ou Senha incorretos");
            return BaseResult;


        }
    }
    }
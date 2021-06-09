using MED.Core.Commands;
using MED.Core.Communication;
using MED.Identidade.API.Application.DTO;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Identidade.API.Application.Messages.Commands.UsuarioCommand
{
    public class UsuarioCommandHandler : CommandHandler,
        IRequestHandler<AdicionarUsuarioCommand, BaseResult>,
        IRequestHandler<AutenticarUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository, ITokenRepository tokenRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _tokenRepository = tokenRepository;
            _configuration = configuration;
        }

        public async Task<BaseResult> Handle(AdicionarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var usuarioExistente = await _usuarioRepository.ObterPorUserNameAsync(command.Email);

            if (usuarioExistente != null)
            {
                AdicionarErro("Este nome de usuário já está em uso por outro usuário!");
                return BaseResult;
            }

            var usuario = new UsuarioModel()
            {
                UserName = command.Email,
                Email = command.Email,
                PhoneNumber = command.Telefone,
                EmailConfirmed = true
            };

            var result = await _usuarioRepository.CriarAsync(usuario, command.Senha);

            if (!result.Succeeded)
            {
                AdicionarErro("Não foi possível incluir o usuário!");
                return BaseResult;
            }

            return BaseResult;
        }

        public async Task<BaseResult> Handle(AutenticarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (!command.Validar()) return command.BaseResult;

            var usuarioExistente= await _usuarioRepository.ObterPorUserNameAsync(command.Email);

            if (usuarioExistente == null)
            {
                AdicionarErro("Este usuário não existe!");
                return BaseResult;
            }

            var result = await _usuarioRepository.LogarAsync(command.Email, command.Senha);

            if (result.Succeeded)
            {
                var expiracao = _configuration["TokenConfiguration:ExpireHours"];
                var token = _tokenRepository.GerarToken(command.Email);
                var dataExpiracao = DateTime.UtcNow.AddHours(double.Parse(expiracao));

                var tokenModel = new TokenModel(command.Email, token, dataExpiracao);
                _tokenRepository.Adicionar(tokenModel);
                await _tokenRepository.SalvarAsync();

                // Retorna o token e demais informações
                var response = new LoginTokenDTO
                {
                    Authenticated = true,
                    Token = token,
                    Expiration = dataExpiracao,
                    Message = "Token JWT OK",
                };

                BaseResult.response = response;
                return BaseResult;
            }

            if (result.IsLockedOut)
            {
                AdicionarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return BaseResult;
            }

            AdicionarErro("Usuário ou Senha incorretos");
            return BaseResult;
        }

    }
}
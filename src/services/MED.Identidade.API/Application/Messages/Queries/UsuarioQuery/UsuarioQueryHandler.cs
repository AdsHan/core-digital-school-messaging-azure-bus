using AutoMapper;
using MED.Identidade.API.Application.DTO;
using MED.Identidade.API.Application.Messages.Queries.UsuarioQuery;
using MED.Identidade.Domain.Entities;
using MED.Identidade.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MED.Identidade.API.Application.Messages.Queries.IdentidadeQuery
{
    public class UsuarioQueryHandler :
        IRequestHandler<ObterTodosUsuariosQuery, List<UsuarioDTO>>,
        IRequestHandler<ObterPorIdUsuarioQuery, UsuarioModel>,
        IRequestHandler<ObterPorUserNameUsuarioQuery, UsuarioModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioDTO>> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();

            var usuariosDTO = _mapper.Map<List<UsuarioDTO>>(usuarios);

            return usuariosDTO;
        }

        public async Task<UsuarioModel> Handle(ObterPorIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id);

            if (usuario == null) return null;

            return usuario;
        }
        public async Task<UsuarioModel> Handle(ObterPorUserNameUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorUserNameAsync(request.UserName);

            if (usuario == null) return null;

            return usuario;
        }

    }

}

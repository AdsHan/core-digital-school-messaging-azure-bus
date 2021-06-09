using MED.Core.Controllers;
using MED.Core.Mediator;
using MED.Core.Utils;
using MED.Identidade.API.Application.Messages.Commands.TokenCommand;
using MED.Identidade.API.Application.Messages.Commands.UsuarioCommand;
using MED.Identidade.API.Application.Messages.Queries.UsuarioQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MED.Identidade.API.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/identidade")]
    [ApiController]
    public class IdentidadeController : BaseController
    {

        private readonly IMediatorHandler _mediator;

        public IdentidadeController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        // GET: api/1.0/identidade
        /// <summary>
        /// Obtêm os usuários
        /// </summary>
        /// <returns>Coleção de objetos da classe Usuário</returns>                
        /// <response code="200">Lista dos usuários</response>        
        /// <response code="400">Falha na requisição</response>         
        /// <response code="404">Nenhum usuário foi localizado</response>         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var obterTodosUsuariosQuery = new ObterTodosUsuariosQuery();

            var usuarios = await _mediator.EnviarQuery(obterTodosUsuariosQuery);

            return ListUtils.isEmpty(usuarios) ? NotFound() : CustomResponse(usuarios);
        }

        // POST api/1.0/identidade
        /// <summary>
        /// Grava o usuário
        /// </summary>   
        /// <remarks>
        /// Exemplo request:
        ///
        ///     POST /Usuario
        ///     {
        ///         "email": "mario@gmail.com",
        ///         "senha": "sys123",
        ///         "telefone": "99 9999-9999",
        ///     }
        /// </remarks>        
        /// <returns>Retorna objeto criado da classe Usuario</returns>                
        /// <response code="201">O usuário foi incluído corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPost("novo-usuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("NovoUsuario")]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarUsuarioCommand command)
        {
            var result = await _mediator.EnviarComando(command);

            return result.ValidationResult.IsValid ? CreatedAtAction("NovoUsuario", new { id = result.response }, command) : CustomResponse(result.ValidationResult);
        }

        // POST api/1.0/identidade
        /// <summary>
        /// Efetua o login do usuário
        /// </summary>   
        /// <remarks>
        /// Exemplo request:
        ///
        ///     POST /Usuario
        ///     {
        ///         "email": "mario@gmail.com",
        ///         "senha": "sys123",
        ///     }
        /// </remarks>        
        /// <returns>Token de autenticação</returns>                
        /// <response code="200">Foi realizado o login corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPost("autenticação")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] AutenticarUsuarioCommand command)
        {
            var result = await _mediator.EnviarComando(command);

            return CustomResponse(result);
        }

        // POST api/1.0/identidade
        /// <summary>
        /// Efetua o atualização do token
        /// </summary>   
        /// <remarks>
        /// Exemplo request:
        ///
        ///     POST /Usuario
        ///     {
        ///         "email": "mario@gmail.com",
        ///         "senha": "sys123",
        ///         "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1hcmlvQGdtYWlsLmNvbSIsImp0aSI6ImM3MTBjZjlhLTU4YzEtNDAxNy04ZTFlLWE2YjI2ZDUzZTRjOSIsImV4cCI6MTYyMzI2OTUzMSwiaXNzIjoiVGVzdGUiLCJhdWQiOiJUZXN0ZSJ9.15vHaGHq6Fi9wwqNssEVAAbydItTYNVpgPsnrAPPBFU",
        ///         
        ///     }
        /// </remarks>        
        /// <returns>Novo Token de autenticação</returns>                
        /// <response code="200">Foi realizada a atualização correta do token</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPost("atualizar-token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarTokenAsync([FromBody] AtualizarTokenCommand command)
        {
            var result = await _mediator.EnviarComando(command);

            return CustomResponse(result);
        }
    }
}

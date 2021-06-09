using MED.Aluno.API.Application.Messages.Commands.AlunoCommand;
using MED.Aluno.API.Application.Messages.Queries.AlunoQuery;
using MED.Core.Controllers;
using MED.Core.Mediator;
using MED.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MED.Aluno.API.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/aluno")]
    [ApiController]
    public class AlunoController : BaseController
    {

        private readonly IMediatorHandler _mediator;

        public AlunoController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        // GET: api/1.0/aluno
        /// <summary>
        /// Obtêm os alunos
        /// </summary>
        /// <returns>Coleção de objetos da classe Aluno</returns>                
        /// <response code="200">Lista dos alunos</response>        
        /// <response code="400">Falha na requisição</response>         
        /// <response code="404">Nenhum aluno foi localizado</response>         
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var obterTodosAlunoQuery = new ObterTodosAlunoQuery();

            var alunos = await _mediator.EnviarQuery(obterTodosAlunoQuery);

            return ListUtils.isEmpty(alunos) ? NotFound() : CustomResponse(alunos);
        }

        // GET: api/1.0/aluno/5
        /// <summary>
        /// Obtêm as informações do aluno pelo seu Id
        /// </summary>
        /// <param name="id">Código do aluno</param>
        /// <returns>Objetos da classe Aluno</returns>                
        /// <response code="200">Informações do Aluno</response>
        /// <response code="400">Falha na requisição</response>         
        /// <response code="404">O aluno não foi localizado</response>         
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var obterPorIdAlunoQuery = new ObterPorIdAlunoQuery(id);

            var aluno = await _mediator.EnviarQuery(obterPorIdAlunoQuery);

            return aluno == null ? NotFound() : CustomResponse(aluno);
        }

        // POST api/1.0/aluno
        /// <summary>
        /// Grava o aluno
        /// </summary>   
        /// <remarks>
        /// Exemplo request:
        ///
        ///     POST /Aluno
        ///     {
        ///         "nome": "Théo da Silva",
        ///         "dataNascimento": "2000-05-27T11:30:07.051Z",
        ///         "rg": "187923607",
        ///         "cpf": "35540251008",      
        ///         "observacao": "Possui alergia a lactose",
        ///         "turmaId": "BCE4F473-3DFA-4FB9-8E1E-5997951F5485",	    
        ///         "responsaveis": [
        ///             {
        ///                 "nome": "João da Silva",
        ///                 "dataNascimento": "2021-05-27T11:30:07.051Z",
        ///                 "rg": "187923607",
        ///                 "cpf": "98283526057",
        ///                 "email": "joao@mail.com",
        ///                 "telefone": "51 99999-9999",
        ///                 "celular": "51 99999-9999",
        ///                 "observacao": "Ligar para a empresa caso não atender"
        ///             },
        ///             {
        ///                 "nome": "Maria Santos da Silva",
        ///                 "dataNascimento": "2000-05-27T11:30:07.051Z",
        ///                 "rg": "473075404",
        ///                 "cpf": "31869845056",
        ///                 "email": "maria@mail.com",
        ///                 "telefone": "51 8888-8888",
        ///                 "celular": "51 8888-8888",
        ///                 "observacao": ""
        ///             }
        ///         ],
        ///         "endereco": {
        ///             "logradouro": "Rua Sol Nascente",
        ///             "numero": "1111",
        ///             "complemento": "string",
        ///             "bairro": "Vista Alegre",
        ///             "cep": "93000-000",
        ///             "cidade": "Ivoti",
        ///             "estado": "RS"
        ///         }
        ///     }
        /// </remarks>        
        /// <returns>Retorna objeto criado da classe Aluno</returns>                
        /// <response code="201">O aluno foi incluído corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ActionName("GravaAluno")]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarAlunoCommand command)
        {
            var result = await _mediator.EnviarComando(command);

            return result.ValidationResult.IsValid ? CreatedAtAction("GravaAluno", new { id = result.response }, command) : CustomResponse(result.ValidationResult);
        }

        // PUT: api/1.0/aluno/5
        /// <summary>
        /// Altera o aluno
        /// </summary>        
        /// <param name="id">Código do aluno</param>        
        /// <response code="204">O aluno foi alterado corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] AlterarAlunoCommand command)
        {
            command.AlunoId = id;

            var result = await _mediator.EnviarComando(command);

            return CustomResponse(result.ValidationResult);
        }

        // DELETE: api/1.0/aluno/5
        /// <summary>
        /// Deleta o aluno pelo seu Id
        /// </summary>        
        /// <param name="id">Código do aluno</param>        
        /// <response code="204">O aluno foi excluído corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new ExcluirAlunoCommand(id);

            var result = await _mediator.EnviarComando(command);

            return CustomResponse(result.ValidationResult);
        }

        // PUT: api/1.0/aluno/alterar-endereco/5
        /// <summary>
        /// Altera o endereço do aluno
        /// </summary>        
        /// <param name="id">Código do aluno</param>        
        /// <response code="200">O aluno foi alterado corretamente</response>                
        /// <response code="400">Falha na requisição</response>         
        [HttpPut("alterar-endereco/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] AlterarEnderecoAlunoCommand command)
        {
            command.AlunoId = id;

            var result = await _mediator.EnviarComando(command);

            return CustomResponse(result.ValidationResult);
        }

    }
}

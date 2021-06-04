using System;

namespace MED.Aluno.API.Application.DTO
{
    public class ResponsavelDTO
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Observacao { get; set; }
    }
}
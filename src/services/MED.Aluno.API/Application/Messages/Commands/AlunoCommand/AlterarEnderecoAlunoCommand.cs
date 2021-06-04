using FluentValidation;
using MED.Core.Commands;
using System;

namespace MED.Aluno.API.Application.Messages.Commands.AlunoCommand
{
    public class AlterarEnderecoAlunoCommand : Command
    {
        public Guid AlunoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override bool Validar()
        {
            BaseResult.ValidationResult = new EnderecoValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class EnderecoValidation : AbstractValidator<AlterarEnderecoAlunoCommand>
        {
            public EnderecoValidation()
            {
                RuleFor(c => c.AlunoId)
                    .NotEmpty()
                    .WithMessage("O código do endereço não foi informado");

                RuleFor(c => c.Logradouro)
                    .NotEmpty()
                    .WithMessage("Informe o Logradouro");

                RuleFor(c => c.Numero)
                    .NotEmpty()
                    .WithMessage("Informe o Número");

                RuleFor(c => c.Cep)
                    .NotEmpty()
                    .WithMessage("Informe o CEP");

                RuleFor(c => c.Bairro)
                    .NotEmpty()
                    .WithMessage("Informe o Bairro");

                RuleFor(c => c.Cidade)
                    .NotEmpty()
                    .WithMessage("Informe o Cidade");

                RuleFor(c => c.Estado)
                    .NotEmpty()
                    .WithMessage("Informe o Estado");
            }
        }
    }
}
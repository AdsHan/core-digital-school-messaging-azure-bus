using FluentValidation;
using MED.Aluno.API.Application.DTO;
using MED.Core.Commands;
using MED.Core.Communication;
using System;
using System.Collections.Generic;

namespace MED.Aluno.API.Application.Messages.Commands.AlunoCommand
{

    public class AlterarAlunoCommand : Command
    {
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Observacao { get; set; }
        public Guid TurmaId { get; set; }
        public List<ResponsavelDTO> Responsaveis { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public override bool Validar()
        {
            BaseResult.ValidationResult = new AlterarAlunoValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class AlterarAlunoValidation : AbstractValidator<AlterarAlunoCommand>
        {
            public AlterarAlunoValidation()
            {
                RuleFor(c => c.AlunoId)
                    .NotEmpty()
                    .WithMessage("O código do aluno não foi informado");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do aluno não foi informado");

                RuleFor(c => c.Nome)
                    .MaximumLength(200)
                    .WithMessage("Tamanho máximo do nome é de 200 caracteres.");

                RuleFor(c => c.Observacao)
                    .MaximumLength(8000)
                    .WithMessage("Tamanho máximo da observação é de 8000 caracteres.");

                RuleFor(c => c.Cpf)
                    .Must(TerCpfValido)
                    .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Rg)
                    .Must(TerRgValido)
                    .WithMessage("O RG informado não é válido.");

                RuleFor(c => c.Responsaveis.Count)
                    .GreaterThan(0)
                    .WithMessage("O Aluno precisa ter no mínimo 1 responsável");
            }

            protected static bool TerCpfValido(string cpf)
            {
                return Core.DomainObjects.Cpf.Validar(cpf);
            }

            protected static bool TerRgValido(string Rg)
            {
                return Core.DomainObjects.Rg.Validar(Rg);
            }
        }
    }
}
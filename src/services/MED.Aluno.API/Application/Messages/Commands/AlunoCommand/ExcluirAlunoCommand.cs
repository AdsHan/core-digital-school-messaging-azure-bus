using FluentValidation;
using MED.Core.Commands;
using System;

namespace MED.Aluno.API.Application.Messages.Commands.AlunoCommand
{

    public class ExcluirAlunoCommand : Command
    {
        public ExcluirAlunoCommand(Guid alunoId)
        {
            AlunoId = alunoId;
        }

        public Guid AlunoId { get; set; }
        public override bool Validar()
        {
            BaseResult.ValidationResult = new ExcluirAlunoValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class ExcluirAlunoValidation : AbstractValidator<ExcluirAlunoCommand>
        {
            public ExcluirAlunoValidation()
            {
                RuleFor(c => c.AlunoId)
                    .NotEmpty()
                    .WithMessage("O código do aluno não foi informado");
            }
        }
    }
}
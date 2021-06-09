﻿using FluentValidation;
using MED.Core.Commands;
using MED.Core.Communication;

namespace MED.Identidade.API.Application.Messages.Commands.UsuarioCommand
{

    public class AdicionarUsuarioCommand : Command
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }

        public override bool Validar()
        {
            BaseResult.ValidationResult = new AdicionarUsuarioValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class AdicionarUsuarioValidation : AbstractValidator<AdicionarUsuarioCommand>
        {
            public AdicionarUsuarioValidation()
            {
                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("O Email do usuário não foi informado");

                RuleFor(c => c.Senha)
                    .NotEmpty()
                    .WithMessage("O senha do usuário foi informado");
            }
        }
    }
}
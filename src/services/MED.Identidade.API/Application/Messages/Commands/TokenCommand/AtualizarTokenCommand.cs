using FluentValidation;
using MED.Core.Commands;
using MED.Core.Communication;

namespace MED.Identidade.API.Application.Messages.Commands.TokenCommand
{

    public class AtualizarTokenCommand : Command
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }

        public override bool Validar()
        {
            BaseResult.ValidationResult = new AtualizarTokenValidation().Validate(this);
            return BaseResult.ValidationResult.IsValid;
        }

        public class AtualizarTokenValidation : AbstractValidator<AtualizarTokenCommand>
        {
            public AtualizarTokenValidation()
            {
                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("O Email do usuário não foi informado");

                RuleFor(c => c.Senha)
                    .NotEmpty()
                    .WithMessage("O senha do usuário foi informado");

                RuleFor(c => c.Token)
                    .NotEmpty()
                    .WithMessage("O token não foi informado");

            }
        }
    }
}
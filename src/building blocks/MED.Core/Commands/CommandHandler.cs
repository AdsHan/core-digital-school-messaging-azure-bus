using FluentValidation.Results;
using MED.Core.Communication;

namespace MED.Core.Commands
{
    public abstract class CommandHandler
    {
        protected BaseResult BaseResult;

        protected CommandHandler()
        {
            BaseResult = new BaseResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            BaseResult.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

    }
}
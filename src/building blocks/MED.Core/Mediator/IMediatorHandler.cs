using MED.Core.Commands;
using MED.Core.Communication;
using System.Threading.Tasks;

namespace MED.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<BaseResult> EnviarComando<T>(T comando) where T : Command;
        Task<object> EnviarQuery<T>(T query);
    }
}
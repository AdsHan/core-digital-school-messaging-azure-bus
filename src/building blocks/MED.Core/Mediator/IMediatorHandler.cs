using MED.Core.Commands;
using MED.Core.Communication;
using System.Threading.Tasks;

namespace MED.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<BaseResult> SendCommand<T>(T command) where T : Command;
        Task<object> SendQuery<T>(T query);
    }
}
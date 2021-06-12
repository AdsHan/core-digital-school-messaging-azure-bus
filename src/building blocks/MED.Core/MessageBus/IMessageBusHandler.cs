using System.Threading.Tasks;

namespace MED.Core.MessageBus
{
    public interface IMessageBusHandler
    {
        Task SendMessage(string queue, Event integration);
    }
}

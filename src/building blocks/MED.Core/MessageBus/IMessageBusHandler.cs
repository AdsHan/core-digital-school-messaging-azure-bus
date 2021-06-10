using System.Threading.Tasks;

namespace MED.Core.MessageBus
{
    public interface IMessageBusHandler
    {
        Task EnviarMenssagem(string queue, Event integration);
    }
}

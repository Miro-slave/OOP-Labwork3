using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adapters;
public class MessengerAdapter : IMessengerAdapter
{
    private IMessenger _messenger;
    public MessengerAdapter()
    {
        _messenger = new Messenger();
    }

    public MessengerAdapter(IMessenger messenger)
    {
        Guard.NotNull(messenger, nameof(messenger));
        _messenger = messenger;
    }

    public void Print(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _messenger.Print(message);
    }
}

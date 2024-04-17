using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adapters;
public interface IMessengerAdapter
{
    public void Print(Message message);
}

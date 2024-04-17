using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;
public class Topic
{
    private IAddressee _messageReceiver;
    public Topic(IAddressee messageReceiver)
    {
        Guard.NotNull(messageReceiver, nameof(messageReceiver));
        _messageReceiver = messageReceiver;
    }

    public void SendMessage(Message message)
    {
        Guard.NotNull(message, nameof(message));
        if (message.ImportanceLevel is MessageImportanceLevel.Necessary
            || _messageReceiver.ImportanceLevel is MessageImportanceLevel.Average)
        {
            _messageReceiver.HandleMessage(message);
        }
    }
}

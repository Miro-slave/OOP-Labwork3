using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public class MessengerAddressee : IAddressee
{
    private ILogger _logger;

    private IMessengerAdapter _messengerAdapter;
    public MessengerAddressee()
    {
        _logger = new Logger();
        _messengerAdapter = new MessengerAdapter();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessengerAddressee(ILogger logger)
    {
        Guard.NotNull(logger, nameof(logger));
        _logger = logger;
        _messengerAdapter = new MessengerAdapter();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessengerAddressee(IMessengerAdapter messengerAdapter)
    {
        Guard.NotNull(messengerAdapter, nameof(messengerAdapter));
        _logger = new Logger();
        _messengerAdapter = messengerAdapter;
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessageImportanceLevel ImportanceLevel { get; set; }
    public IEnumerable<MessageLog> MessageLogs { get { return _logger.MessageLogs; } }
    public void HandleMessage(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _logger.AddLogs(message);
        _messengerAdapter.Print(message);
    }
}

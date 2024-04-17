using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public class DisplayAddressee : IAddressee
{
    private ILogger _logger;

    private IDisplayAdapter _displayAdapter;
    public DisplayAddressee()
    {
        _logger = new Logger();
        _displayAdapter = new DisplayAdapter();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public DisplayAddressee(ILogger logger)
    {
        Guard.NotNull(logger, nameof(logger));
        _logger = logger;
        _displayAdapter = new DisplayAdapter();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public DisplayAddressee(IDisplayAdapter messengerAdapter)
    {
        Guard.NotNull(messengerAdapter, nameof(messengerAdapter));
        _logger = new Logger();
        _displayAdapter = messengerAdapter;
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessageImportanceLevel ImportanceLevel { get; set; }
    public IEnumerable<MessageLog> MessageLogs { get { return _logger.MessageLogs; } }
    public void HandleMessage(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _logger.AddLogs(message);
        _displayAdapter.Clear();
    }

    public void PrintConsole(Message message)
    {
        Guard.NotNull(message, nameof(message));
        HandleMessage(message);
        _displayAdapter.PrintConsole(message);
    }

    public void PrintFile(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _logger.AddLogs(message);
        _displayAdapter.Clear();
    }
}

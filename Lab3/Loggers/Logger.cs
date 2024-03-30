using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;
public class Logger : ILogger
{
    private List<MessageLog> _messageLogs;
    public Logger()
    {
        _messageLogs = new List<MessageLog>();
    }

    public IEnumerable<MessageLog> MessageLogs { get { return _messageLogs; } }
    public void AddLogs(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _messageLogs.Add(new MessageLog(message.Id));
    }
}

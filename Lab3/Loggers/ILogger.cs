using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;
public interface ILogger
{
    public IEnumerable<MessageLog> MessageLogs { get; }
    public void AddLogs(Message message);
}

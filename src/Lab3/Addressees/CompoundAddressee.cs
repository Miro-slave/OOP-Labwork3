using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public class CompoundAddressee : IAddressee
{
    private ILogger _logger;
    public CompoundAddressee()
    {
        _logger = new Logger();
        Addressees = new List<IAddressee>();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public CompoundAddressee(ILogger logger)
    {
        Guard.NotNull(logger, nameof(logger));
        _logger = logger;
        Addressees = new List<IAddressee>();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessageImportanceLevel ImportanceLevel { get; set; }
    public IEnumerable<MessageLog> MessageLogs { get { return _logger.MessageLogs; } }
    public ICollection<IAddressee> Addressees { get; }
    public void HandleMessage(Message message)
    {
        Guard.NotNull(message, nameof(message));

        foreach (IAddressee addressee in Addressees)
        {
            addressee.HandleMessage(message);
        }

        _logger.AddLogs(message);
    }
}

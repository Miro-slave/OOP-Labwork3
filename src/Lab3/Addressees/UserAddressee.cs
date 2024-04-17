using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public class UserAddressee : IAddressee
{
    private ILogger _logger;

    private ICollection<Message> _messages;
    public UserAddressee()
    {
        _logger = new Logger();
        _messages = new List<Message>();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public UserAddressee(ILogger logger)
    {
        Guard.NotNull(logger, nameof(logger));
        _logger = logger;
        _messages = new List<Message>();
        ImportanceLevel = new MessageImportanceLevel.Average();
    }

    public MessageImportanceLevel ImportanceLevel { get; set; }
    public IEnumerable<MessageLog> MessageLogs { get { return _logger.MessageLogs; } }
    public void HandleMessage(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _logger.AddLogs(message);
        _messages.Add(message);
    }

    public void SetMessageStatus(int messageId, MessageStatus messageStatus)
    {
        Guard.NotNull(messageStatus, nameof(messageStatus));
        Message? message = _messages.FirstOrDefault(message => message.Id == messageId);

        if (message == null)
        {
            throw new CannotFindMessageByIdException();
        }
        else if (message.Status is MessageStatus.Viewed && messageStatus is MessageStatus.Unviewed)
        {
            throw new ChangeViewedMessageStatusException();
        }
        else
        {
            message.Status = messageStatus;
        }
    }
}

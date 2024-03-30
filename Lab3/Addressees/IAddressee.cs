using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;
public interface IAddressee
{
    public IEnumerable<MessageLog> MessageLogs { get; }
    MessageImportanceLevel ImportanceLevel { get; set; }
    public void HandleMessage(Message message);
}

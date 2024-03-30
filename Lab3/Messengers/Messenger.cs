using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;
public class Messenger : IMessenger
{
    public Messenger()
    {
        StringStream = new StringBuilder();
        StringStream.AppendLine("Messenger");
    }

    private StringBuilder StringStream { get; }
    public void Print(Message message)
    {
        Guard.NotNull(message, nameof(message));
        StringStream.AppendLine(message.Title);
        StringStream.AppendLine(message.Body);

        Console.WriteLine(StringStream);
    }

    public string GetChat()
    {
        return StringStream.ToString();
    }
}

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public abstract record MessageStatus
{
    private MessageStatus() { }
#pragma warning disable CA1034
    public sealed record Viewed : MessageStatus;

    public sealed record Unviewed : MessageStatus;
#pragma warning restore CA1034
}
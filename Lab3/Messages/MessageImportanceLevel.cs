namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;
public abstract record MessageImportanceLevel
{
    private MessageImportanceLevel() { }
#pragma warning disable CA1034
    public sealed record Average : MessageImportanceLevel;

    public sealed record Necessary : MessageImportanceLevel;
#pragma warning restore CA1034
}
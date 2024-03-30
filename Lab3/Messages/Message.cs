namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;
public class Message
{
    public Message(
        string title,
        string body,
        int id,
        MessageImportanceLevel importanceLevel)
    {
        Guard.NotNull(title, nameof(title));
        Guard.NotNull(body, nameof(body));
        Guard.NotNull(importanceLevel, nameof(importanceLevel));
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
        Id = id;
        Status = new MessageStatus.Unviewed();
    }

    public int Id { get; }
    public string Title { get; }
    public string Body { get; }
    public MessageImportanceLevel ImportanceLevel { get; }
    public MessageStatus Status { get; set; }
}

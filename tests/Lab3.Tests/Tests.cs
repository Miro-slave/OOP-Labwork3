using Itmo.ObjectOrientedProgramming.Lab3.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    private static Message _unnecessaryMessage = new Message(
        "For Laura",
        "Nice to hear form you again!",
        70012,
        new MessageImportanceLevel.Average());

    [Fact]
    public void TestUnviewedMessage()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var addressee = new UserAddressee();
        var topic = new Topic(addressee);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.IsType<MessageStatus.Unviewed>(message.Status);
    }

    [Fact]
    public void TestChangeMessageStatusValid()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var addressee = new UserAddressee();
        var topic = new Topic(addressee);

        topic.SendMessage(message);

        // Act
        addressee.SetMessageStatus(message.Id, new MessageStatus.Viewed());

        // Assert
        Assert.IsType<MessageStatus.Viewed>(message.Status);
    }

    [Fact]
    public void TestChangeMessageStatusInvalid()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var addressee = new UserAddressee();
        var topic = new Topic(addressee);

        topic.SendMessage(message);
        addressee.SetMessageStatus(message.Id, new MessageStatus.Viewed());

        // Act & Assert
        Assert.Throws<ChangeViewedMessageStatusException>(() => addressee.SetMessageStatus(message.Id, new MessageStatus.Unviewed()));
    }

    [Fact]
    public void TestNonEssentialMessageNotPass()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var addressee = new Mock<IAddressee>();
        addressee.Object.ImportanceLevel = new MessageImportanceLevel.Necessary();
        var topic = new Topic(addressee.Object);

        // Act
        topic.SendMessage(message);

        // Assert
        addressee.Verify(x => x.HandleMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void TestLoggingAfterReceivingMessage()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var logger = new Mock<ILogger>();
        var addressee = new UserAddressee(logger.Object);
        var topic = new Topic(addressee);

        // Act
        topic.SendMessage(message);

        // Assert
        logger.Verify(x => x.AddLogs(It.IsAny<Message>()), Times.Once);
    }

    [Fact]
    public void TestValidMessengerOutput()
    {
        // Arrange
        Message message = _unnecessaryMessage;
        var messenger = new Mock<Messenger>();
        var messengerAdapter = new MessengerAdapter(messenger.Object);
        var addressee = new MessengerAddressee(messengerAdapter);
        var topic = new Topic(addressee);

        // Act
        topic.SendMessage(message);

        string answer =
            "Messenger" + System.Environment.NewLine +
            message.Title + System.Environment.NewLine +
            message.Body + System.Environment.NewLine;

        // Assert
        Assert.Equal(answer, messenger.Object.GetChat());
    }
}
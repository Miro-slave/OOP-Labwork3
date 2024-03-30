using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ChangeViewedMessageStatusException : Exception
{
    public ChangeViewedMessageStatusException()
    {
    }

    public ChangeViewedMessageStatusException(string message)
        : base(message)
    {
    }

    public ChangeViewedMessageStatusException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

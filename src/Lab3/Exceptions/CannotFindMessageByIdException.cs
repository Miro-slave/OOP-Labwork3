using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
public class CannotFindMessageByIdException : Exception
{
    public CannotFindMessageByIdException()
    {
    }

    public CannotFindMessageByIdException(string message)
        : base(message)
    {
    }

    public CannotFindMessageByIdException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
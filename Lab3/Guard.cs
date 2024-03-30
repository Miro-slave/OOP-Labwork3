using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;
public static class Guard
{
    public static T NotNull<T>(T? parameter, string parameterName)
        where T : class
    {
        if (parameter is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return parameter;
    }
}
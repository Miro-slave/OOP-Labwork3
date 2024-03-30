using System;
using System.IO;
using Crayon;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;
public class DisplayDriver : IDisplay
{
    public void Clear()
    {
        Console.Clear();
    }

    public void PrintConsole(IOutput output)
    {
        Guard.NotNull(output, nameof(output));
        Console.WriteLine(output);
    }

    public void PrintFile(IOutput output, string filePath)
    {
        Guard.NotNull(output, nameof(output));
        Guard.NotNull(filePath, nameof(filePath));
        File.WriteAllText(filePath, output.ToString());
    }
}

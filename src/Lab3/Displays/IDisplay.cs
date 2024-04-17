using Crayon;
namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;
public interface IDisplay
{
    void Clear();
    void PrintConsole(IOutput output);
    void PrintFile(IOutput output, string filePath);
}

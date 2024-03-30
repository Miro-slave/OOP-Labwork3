using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adapters;
public interface IDisplayAdapter
{
    public void SetColor(byte r = 255, byte g = 255, byte b = 255);
    public void PrintConsole(Message message);
    public void PrintFile(Message message, string filePath);
    public void Clear();
}

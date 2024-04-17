using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using static Crayon.Output;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adapters;
public class DisplayAdapter : IDisplayAdapter
{
    private Crayon.IOutput _textFormat;
    private IDisplay _adaptee;
    private byte _r; private byte _g; private byte _b;
    public DisplayAdapter()
    {
        _r = 255;
        _g = 255;
        _b = 255;
        _textFormat = Rgb(_r, _g, _b);
        _adaptee = new DisplayDriver();
    }

    public void SetColor(byte r = 255, byte g = 255, byte b = 255)
    {
        _r = r;
        _g = g;
        _b = b;
    }

    public void PrintConsole(Message message)
    {
        Guard.NotNull(message, nameof(message));
        _textFormat
            .Rgb(_r, _g, _b)
            .Append(message.Title)
            .Append(message.Title);

        _adaptee.PrintConsole(_textFormat);
    }

    public void PrintFile(Message message, string filePath)
    {
        Guard.NotNull(message, nameof(message));
        _textFormat
            .Append(message.Title)
            .Append(message.Body);

        _adaptee.PrintFile(_textFormat, filePath);
    }

    public void Clear()
    {
        _adaptee.Clear();
    }
}

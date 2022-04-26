namespace Demo.Core.LineParsers;

public class DefaultLineParser : ILineParser
{
    public bool CanParse(string line)
        => true;

    public void Parse(string line, PlayerSettings settings)
    {
        AnsiConsole.Markup(line);
        AnsiConsole.WriteLine();
    }
}
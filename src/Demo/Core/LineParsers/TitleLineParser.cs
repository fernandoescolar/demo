namespace Demo.Core.LineParsers;

public class TitleLineParser : ILineParser
{
    public bool CanParse(string line)
        => line.StartsWith("#", StringComparison.OrdinalIgnoreCase);

    public void Parse(string line, Settings settings)
    {
        line = line.Substring(1);
        var rule = new Rule($"[{settings.TitleColor}]{settings.TitlePrefix}{line}[/]")
                        .Alignment(Justify.Right)
                        .Border(BoxBorder.None);
        AnsiConsole.Write(rule);
    }
}

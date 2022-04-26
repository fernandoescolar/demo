namespace Demo.Core.LineParsers;

public class CommandLineParser : ILineParser
{
    public bool CanParse(string line)
        => line.StartsWith("$", StringComparison.OrdinalIgnoreCase);

    public void Parse(string line, Settings settings)
    {
        line = line.Substring(1);
        AnsiConsole.Markup(settings.Prompt);
        var arguments = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var first = true;
        foreach (var word in arguments)
        {
            ParseWord(word, settings, first);
            first = false;
            Console.ReadKey(true);
            AnsiConsole.Write(" ");
            AnsiConsole.ResetColors();
        }

        WaitEnter();

        AnsiConsole.WriteLine();
    }

    private void ParseWord(string word, Settings settings, bool first)
    {
        if (first)
        {
            AnsiConsole.Foreground = Color.Blue;
        }
        else if (word.StartsWith("$"))
        {
            AnsiConsole.Foreground = Color.Cyan1;
        }
        else if (word.StartsWith("-"))
        {
            AnsiConsole.Foreground = Color.Grey;
        }

        if (word.StartsWith("-") && settings.CommandArgumentsBreakLine)
        {
            Console.ReadKey(true);
            AnsiConsole.Write(" \\");
            Console.ReadKey(true);
            AnsiConsole.WriteLine();
        }

        foreach (var c in word)
        {
            if (c == '=')
            {
                AnsiConsole.Foreground = Color.Cyan3;
            }

            Console.ReadKey(true);
            AnsiConsole.Write(c);
            if (c == '=')
            {
                AnsiConsole.ResetColors();
            }
        }
    }

    private static void WaitEnter()
    {
        while (Console.ReadKey(true).Key != ConsoleKey.Enter) // wait to enter
        {
            AnsiConsole.Write(".");
            Thread.Sleep(100);
            AnsiConsole.Write("\b \b");
        }
    }
}
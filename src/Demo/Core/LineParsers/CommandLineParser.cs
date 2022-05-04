namespace Demo.Core.LineParsers;

public class CommandLineParser : ILineParser
{
    public bool CanParse(string line)
        => line.StartsWith("$", StringComparison.OrdinalIgnoreCase);

    public void Parse(string line, PlayerSettings settings)
    {
        line = line.Substring(1);
        AnsiConsole.Markup(settings.Prompt);
        var arguments = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var first = true;
        InputReader.ResetCommand();
        foreach (var word in arguments)
        {
            ParseWord(word, settings, first);
            first = false;
            InputReader.ReadKey();
            AnsiConsole.Write(" ");
            AnsiConsole.ResetColors();
        }

        InputReader.WaitEnter();

        AnsiConsole.WriteLine();
    }

    private void ParseWord(string word, PlayerSettings settings, bool first)
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
            InputReader.ReadKey();
            AnsiConsole.Write(" \\");
            InputReader.ReadKey();
            AnsiConsole.WriteLine();
        }

        foreach (var c in word)
        {
            if (c == '=')
            {
                AnsiConsole.Foreground = Color.Cyan3;
            }

            InputReader.ReadKey();
            AnsiConsole.Write(c);
            if (c == '=')
            {
                AnsiConsole.ResetColors();
            }
        }
    }

    class InputReader
    {
        private static bool Skip = false;

        public static void ReadKey()
        {
            if (Skip) return;

            var key = Console.ReadKey(true);
            if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Enter)
            {
                Skip = true;
            }
        }

        public static void WaitEnter()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) // wait to enter
            {
                AnsiConsole.Write(".");
                Thread.Sleep(100);
                AnsiConsole.Write("\b \b");
            }
        }

        public static void ResetCommand()
        {
            Skip = false;
        }
    }
}
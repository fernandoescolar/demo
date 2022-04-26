namespace Demo.Core;

public class Scripter
{
    private readonly ScripterSettings _settings;

    public Scripter(ScripterSettings settings)
    {
        _settings = settings;
    }

    public void Run(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException(filepath);
        }

        if (_settings.AddBashScriptHeader)
        {
            AnsiConsole.WriteLine("#!/bin/bash");
        }

        using var file = new StreamReader(filepath);
        while (!file.EndOfStream)
        {
            var line = file.ReadLine() ?? string.Empty;
            ParseLine(line);
        }
    }

    private void ParseLine(string line)
    {
        if (line.StartsWith('#') && _settings.ShowTitles)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine($"echo \"{line.Substring(1).Trim()}\"");
        }

        if (line.StartsWith('$'))
        {
            if (_settings.CommandArgumentsBreakLine)
            {
                var arguments = line.Substring(1).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach(var arg in arguments)
                {
                     if (arg.StartsWith("-"))
                     {
                         AnsiConsole.WriteLine(_settings.CommandArgumentsBreakLinePrefix ?? string.Empty);
                     }

                     AnsiConsole.Write(arg);
                     AnsiConsole.Write(" ");
                }

                AnsiConsole.WriteLine();
            }
            else
            {
                AnsiConsole.WriteLine($"{line.Substring(1).Trim()}");
            }
        }
    }
}
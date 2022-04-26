namespace Demo.Core;

public class Player
{
    private readonly Settings _settings;
    private readonly IEnumerable<ILineParser> _lineParsers;

    public Player(Settings settings, IEnumerable<ILineParser> lineParsers)
    {
        _settings = settings;
        _lineParsers = lineParsers;
    }

    public void Play(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException(filepath);
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
        foreach (var lineParser in _lineParsers)
        {
            if (lineParser.CanParse(line))
            {
                lineParser.Parse(line, _settings);
                return;
            }
        }
    }
}

namespace Demo.Core;

public interface ILineParser
{
    bool CanParse(string line);
    void Parse(string line, Settings settings);
}
namespace Demo.Core.LineParsers;

public class FunctionLineParser : ILineParser
{
    private IEnumerable<IFunction> _functions;

    public FunctionLineParser(IEnumerable<IFunction> functions)
    {
        _functions = functions;
    }

    public bool CanParse(string line)
        => line.StartsWith("@", StringComparison.OrdinalIgnoreCase);

    public void Parse(string line, Settings settings)
    {
        line = line.Substring(1);
        foreach(var function in _functions)
        {
            if (function.CanExecute(line))
            {
                function.Execute(line, settings);
                return;
            }
        }
    }
}
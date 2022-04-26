namespace Demo.Core.LineParsers.Functions;

public class ClearFunction : IFunction
{
    public bool CanExecute(string line)
        => line.Equals("clear", StringComparison.OrdinalIgnoreCase);

    public void Execute(string line, PlayerSettings settings)
    {
        AnsiConsole.Clear();
    }
}

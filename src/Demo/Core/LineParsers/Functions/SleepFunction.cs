namespace Demo.Core.LineParsers.Functions;

public class SleepFunction : IFunction
{
    public bool CanExecute(string line)
        => line.StartsWith("sleep") && int.TryParse(line.Substring(6), out var _);

    public void Execute(string line, PlayerSettings settings)
    {
        Thread.Sleep(int.Parse(line.Substring(6)));
    }
}

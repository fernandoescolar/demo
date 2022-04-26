namespace Demo.Core.LineParsers.Functions;

public class RunningFunction : IFunction
{
    public bool CanExecute(string line)
        => line.StartsWith("running") && int.TryParse(line.Substring(8), out var _);

    public void Execute(string line, PlayerSettings settings)
    {
        AnsiConsole.Status()
                   .AutoRefresh(true)
                   .Spinner(Spinner.Known.Ascii)
                   .SpinnerStyle(Style.Parse("green bold"))
                   .Start("Running ..", _ => Thread.Sleep(int.Parse(line.Substring(8))));
    }
}

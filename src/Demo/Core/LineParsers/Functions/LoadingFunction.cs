namespace Demo.Core.LineParsers.Functions;

public class LoadingFunction : IFunction
{
    public bool CanExecute(string line)
        => line.StartsWith("loading") && int.TryParse(line.Substring(8), out var _);

    public void Execute(string line, Settings settings)
    {
        AnsiConsole.Status()
                   .AutoRefresh(true)
                   .Spinner(Spinner.Known.Ascii)
                   .SpinnerStyle(Style.Parse("yellow bold"))
                   .Start("Loading ...", _ => Thread.Sleep(int.Parse(line.Substring(8))));
    }
}
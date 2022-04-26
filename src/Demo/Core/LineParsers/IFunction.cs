namespace Demo.Core.LineParsers;

public interface IFunction
{
    public bool CanExecute(string line);
    public void Execute(string line, PlayerSettings settings);
}

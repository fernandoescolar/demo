namespace Demo.Core.LineParsers.Functions;

public class PromptFunction : IFunction
{
    public bool CanExecute(string line)
        => line.StartsWith("prompt", StringComparison.OrdinalIgnoreCase);

    public void Execute(string line, Settings settings)
    {
        settings.Prompt = line.Substring(7)
                              .Replace("\\s", " ")
                              .Replace("\\n", "\n")
                              .Replace("\\r", "\r")
                              .Replace("\\t", "\t");
    }
}

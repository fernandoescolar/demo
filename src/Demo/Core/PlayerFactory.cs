namespace Demo.Core;
public class PlayerFactory
{
    public static Player Create(Settings? settings = null)
    {
        settings = settings ?? new Settings();
        return new Player(settings, GetLineParsers());
    }

    private static IEnumerable<ILineParser> GetLineParsers()
        => new ILineParser[]
        {
            new CommandLineParser(),
            new TitleLineParser(),
            new FunctionLineParser(GetFunctions()),
            new DefaultLineParser()
        };

    private static IEnumerable<IFunction> GetFunctions()
        => new IFunction[]
        {
            new PromptFunction(),
            new ClearFunction(),
            new SleepFunction(),
            new RunningFunction(),
            new LoadingFunction()
        };
}
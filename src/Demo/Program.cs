namespace Demo;

public class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp();
        app.Configure(config => {
            config.AddCommand<PlayCommand>("play")
                  .WithDescription("Start demo using the given script file.");
            config.AddCommand<ScriptCommand>("script")
                  .WithDescription("Scripts the demo commands using the given script file.");
        });

        try
        {
            return app.Run(args);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return 1;
        }
    }
}

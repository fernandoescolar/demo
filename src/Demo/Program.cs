namespace Demo;

public class Program
{
    public static int Main(string[] args)
    {
        var app = new CommandApp<PlayerCommand>();
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

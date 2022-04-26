namespace Demo.Commands;

internal sealed class ScriptCommand : Command<ScriptCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("FilePath to the script file to play.")]
        [CommandArgument(0, "<filepath>")]
        public string? FilePath { get; init; }

        [Description("(true|false) Add line breaks before command arguments.")]
        [CommandOption("-b|--line-breaks")]
        [DefaultValue(true)]
        public bool CommandArgumentsBreakLine { get; init; }

        [Description("Add line breaks before command arguments. p.e. -p \"  \"")]
        [CommandOption("-p|--arguments-prefix")]
        [DefaultValue("  ")]
        public string? CommandArgumentsBreakLinePrefix { get; init; }

        [Description("(true|false) Add an 'echo' with the titles.")]
        [CommandOption("-t|--show-titles")]
        [DefaultValue(true)]
        public bool ShowTitles { get; init; }

        [Description("(true|false) Add the bash script header line at the begining of the script.")]
        [CommandOption("-a|--bash-header")]
        [DefaultValue(false)]
        public bool AddBashScriptHeader { get; init; }

        public override ValidationResult Validate()
        {
            return string.IsNullOrWhiteSpace(FilePath)
                ? ValidationResult.Error("FilePath must be specified")
                : ValidationResult.Success();
        }
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.FilePath))
        {
            AnsiConsole.Markup("[red]FilePath must be specified[red]");
            return 1;
        }

        var s = new ScripterSettings
        {
            CommandArgumentsBreakLine = settings.CommandArgumentsBreakLine,
            CommandArgumentsBreakLinePrefix = settings.CommandArgumentsBreakLinePrefix,
            ShowTitles = settings.ShowTitles,
            AddBashScriptHeader = settings.AddBashScriptHeader
        };
        var scripter = new Scripter(s);
        scripter.Run(settings.FilePath);

        return 0;
    }
}
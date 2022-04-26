namespace Demo.Commands;

internal sealed class PlayCommand : Command<PlayCommand.Settings>
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

        var s = new PlayerSettings { CommandArgumentsBreakLine = settings.CommandArgumentsBreakLine };
        var player = PlayerFactory.Create(s);
        player.Play(settings.FilePath);
        return 0;
    }
}

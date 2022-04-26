namespace Demo;

internal sealed class PlayerCommand : Command<PlayerCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("FilePath to the script file to play.")]
        [CommandArgument(0, "[filePath]")]
        public string? FilePath { get; init; }

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

        var player = PlayerFactory.Create();
        player.Play(settings.FilePath);
        return 0;
    }
}
namespace Demo.Core;

public class ScripterSettings
{
    public bool AddBashScriptHeader { get; set; } = false;

    public bool ShowTitles { get; set; } = true;

    public bool CommandArgumentsBreakLine { get; set; } = true;

    public string? CommandArgumentsBreakLinePrefix { get; set; } = "  ";
}

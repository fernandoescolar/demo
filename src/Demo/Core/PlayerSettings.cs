namespace Demo.Core;

public class PlayerSettings
{
    public string Prompt { get; set; } = "$ ";
    public object TitleColor { get; set; } = "gray";
    public object TitlePrefix { get; set; }= "# ";
    public bool CommandArgumentsBreakLine { get; set; } = true;
}
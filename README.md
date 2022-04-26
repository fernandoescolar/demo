# demo

It's a tool to assist you in your presentation terminal demonstrations

## Getting started

Install latest version using `dotnet` client: (**recomended**)

```bash
dotnet tool install --global demo-cli
```

Or update to latest version:

```bash
dotnet tool update --global demo-cli
```

Create a file called `hello.bash` with the content bellow:

```bash
@prompt [green]hello[/]\n$\s
@loading 2000
# set variable
$ text="hello world"

# show variable value
$ echo $text
@running 2000
hello world
@sleep 2000
bye
@clear
```

And run it:

```bash
demo hello.bash
```

> Note: in order to see commands (lines starting with `$`) you need to press any key and finnaly press `Enter` key to go to the next step.

## Instructions

### Title

The line starting with `#` will be used as the title. A title is written in gray and aligned to the right on the terminal.

p.e.
```bash
# my title
```

### Command

The line starting with `$` is a command.

If you want to get a command output, you need to press any key until all the text is typed. And to go to the next step you need to press the `Enter` key.

p.e.
```bash
$ tar tf file.tgz
```

### Function

The line starting with `@` will be evaluated to execute a function.

Function list:

- `@clear`: clears the terminal.
- `@prompt {markup}`: changes the user prompt. The user prompt is written before a command.
- `@sleep {millis}`: sleeps for the specified number of milliseconds.
- `@loading {millis}`: shows a loading animation for the specified number of milliseconds.
- `@running {millis}`: shows a running animation for the specified number of milliseconds.

p.e
```bash
@prompt [green]hello[/]\s#\s
@sleep 2000
@loading 2000
@running 2000
@clear
```
### General output

Any other line will be use a general output.

p.e
```bash
hello world
| a   |  b  |  c  |
-------------------
| 1   |  2  |  3  |
| 4   |  5  |  6  |
| 7   |  8  |  9  |
```

## Markup

To render a text interminal **demo** uses [Spectre.Console]https://spectreconsole.net(). You can use this library [markup language](https://spectreconsole.net/markup) and [emojis](https://spectreconsole.net/appendix/emojis) to render rich text.

p.e
```bash
# colors
[red]Foo[/]
[#ff0000]Bar[/]
[rgb(255,0,0)]Baz[/]
# back colors
[bold yellow on blue]Hello[/]
# emojis
Hello :globe_showing_europe_africa:!
# escaped
[[Hello]]
```

## License

The source code we develop at **demo** is default being licensed as MIT. You can read more about [here](LICENSE.md).

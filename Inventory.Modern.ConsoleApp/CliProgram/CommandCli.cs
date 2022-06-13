using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Modern.ConsoleApp;

public class CommandCli 
    : AppProgUnity<CommandCli>
{
    [Subcommand]
    public ItemCommands? ItemCommands { get; set; }

    [Subcommand]
    public ContainerCommands? ContainerCommands { get; set; }

    [Subcommand]
    public CategoryCommands? CategoryCommands { get; set; }

    [Subcommand]
    public SizeCommands? SizeCommands { get; set; }

    [Subcommand]
    public ImageCommands? ImageCommands { get; set; }

    [Subcommand]
    public StockCommands? StockCommands { get; set; }

    [Subcommand]
    public StockCountCommands? StockCountCommands { get; set; }

    [Subcommand]
    public StateCommands? StateCommands { get; set; }

    public CommandCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}
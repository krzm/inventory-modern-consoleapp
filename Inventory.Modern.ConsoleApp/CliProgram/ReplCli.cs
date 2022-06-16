using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Modern.ConsoleApp;

public class ReplCli
    : AppProgUnity<ReplCli>
{
    private static bool inSession;

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
    
    public ReplCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context
        , ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}
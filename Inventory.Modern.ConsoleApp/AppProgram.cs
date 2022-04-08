using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Modern.ConsoleApp;

public class AppProg 
    : AppProgUnity<AppProg>
{
    private static bool inSession;

    [Subcommand]
    public ItemCommands? ItemCommands { get; set; }

    [Subcommand]
    public ItemCategoryCommands? ItemCategoryCommands { get; set; }

    [Subcommand]
    public ItemDetailCommands? ItemDetailCommands { get; set; }

    [Subcommand]
    public ItemImageCommands? ItemImageCommands { get; set; }

    [Subcommand]
    public StockCommands? StockCommands { get; set; }

    [Subcommand]
    public StockDetailCommands? StockDetailCommands { get; set; }

    public AppProg(
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
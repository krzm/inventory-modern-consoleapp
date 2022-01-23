using CommandDotNet;
using CommandDotNet.Repl;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class AppProgram : Console.Modern.Lib.AppProgramUnity<AppProgram>
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

    public AppProgram(
        IUnityContainer container)
            : base(container)
    {
    }

    [DefaultCommand()]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "CommandDotNet needs instance member")]
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

    protected override void RegisterCommandClasses(AppRunner appRunner)
    {
        var commandClassTypes = appRunner.GetCommandClassTypes();
        var registeredExplicitly = new Type[]
        {
            //typeof()
        };
        foreach (var type in commandClassTypes)
        {
            if (registeredExplicitly.Contains(type.type)) continue;
            Container.RegisterSingleton(type.type);
        }
    }
}
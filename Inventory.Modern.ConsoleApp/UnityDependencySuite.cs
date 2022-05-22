using CLIHelper.Unity;
using CommandDotNet.Unity.Helper;
using Config.Wrapper.Unity;
using Inventory.Data;
using Inventory.Modern.Lib;
using Inventory.Table.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class UnityDependencySuite 
    : DIHelper.Unity.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
    }
    
    protected override void RegisterDatabase() =>
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();
        
    protected override void RegisterConsoleOutput() =>
        RegisterSet<InventoryTableSet>();

    protected override void RegisterDataMappings() =>
        RegisterSet<AppMappings>();

    protected override void RegisterCommands() =>
        RegisterSet<AppCommands>();

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<AppProg>>();
}
using CLIHelper.Unity;
using DIHelper.Unity;
using Inventory.Data;
using Inventory.Modern.Lib;
using Inventory.Table.Unity;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public abstract class InventorySuite 
    : UnityDependencySuite
{
    public InventorySuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterDatabase() =>
        RegisterSet<InventoryDatabase>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();
        
    protected override void RegisterConsoleOutput() =>
        RegisterSet<InventoryTableSet>();

    protected override void RegisterDataMappings() =>
        RegisterSet<AppMappings>();

    protected override void RegisterCommands() =>
        RegisterSet<AppCommands>();
}
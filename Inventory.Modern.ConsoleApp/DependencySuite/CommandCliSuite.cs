using CommandDotNet.Unity.Helper;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class CommandCliSuite 
    : InventorySuite
{
    public CommandCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<CommandCli>>();
}
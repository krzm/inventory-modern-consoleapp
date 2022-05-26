using CommandDotNet.Unity.Helper;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class ReplCliSuite 
    : InventorySuite
{
    public ReplCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<ReplCli>>();
}
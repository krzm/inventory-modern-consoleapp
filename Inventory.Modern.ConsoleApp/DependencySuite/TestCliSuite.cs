using CLIHelper.Unity;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class TestCliSuite 
    : CommandCliSuite
{
    public TestCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIODebugSet>();
}
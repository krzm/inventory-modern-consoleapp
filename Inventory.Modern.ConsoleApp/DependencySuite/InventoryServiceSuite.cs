using Config.Wrapper.Unity;
using DIHelper.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class InventoryServiceSuite 
    : UnityDependencySuite
{
    public InventoryServiceSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();  
    }
}
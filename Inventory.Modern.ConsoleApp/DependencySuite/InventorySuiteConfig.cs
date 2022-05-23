using Config.Wrapper;
using DIHelper;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class InventorySuiteConfig
{
    private readonly IConfigReader configReader;

    public InventorySuiteConfig(
        IConfigReader configReader
    )
    {
        this.configReader = configReader;
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        // var config = configReader.GetConfigSection<InventoryDbType>(nameof(InventoryDbType));
        // if (config == null)
        //     throw new Exception($"Cant load config section {nameof(InventoryDbType)}");
        // else
        // {
        //     switch (config.DbType)
        //     {
        //         case DbType.Local:
        //             return new InventorySuite(unity);
        //         case DbType.LocalTest:
        //             return new InventoryLocalTestDbSuite(unity);
        //         default :
        //             return new InventorySuite(unity);
        //     }
        // }
        return new InventorySuite(unity);
    }
}
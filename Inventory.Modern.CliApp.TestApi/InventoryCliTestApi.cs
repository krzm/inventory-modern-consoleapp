using DIHelper;
using Inventory.Data;
using Inventory.Modern.ConsoleApp;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class InventoryCliTestApi
{
    protected static InventoryBootstraper GetBooter()
    {
        var booter = new InventoryBootstraper();
        booter.CreateApp();
        return booter;
    }

    protected static IInventoryUnitOfWork GetUnitOfWork(
        InventoryBootstraper booter)
    {
        var unitOfWork = booter.Suite?.Resolve<IInventoryUnitOfWork>();
        ArgumentNullException.ThrowIfNull(unitOfWork);
        return unitOfWork;
    }

    protected static void RunCmd(
        IBootstraper booter
        , string cmd)
    {
        if(cmd.Contains(" ") == false)
            booter.RunApp(cmd);
        else 
            booter.RunApp(cmd.Split(' '));
    }   
}
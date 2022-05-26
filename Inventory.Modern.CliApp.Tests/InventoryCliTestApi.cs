using DIHelper;
using Inventory.Data;
using CliAppl = Inventory.Modern.ConsoleApp.CliApp;

namespace Inventory.Modern.CliApp.Tests;

public abstract class InventoryCliTestApi
{
    protected static CliAppl GetBooter()
    {
        var app = new CliAppl();
        app.CreateApp();
        return app;
    }

    protected static IInventoryUnitOfWork GetUnitOfWork(
        CliAppl app)
    {
        var unitOfWork = app.Suite?.Resolve<IInventoryUnitOfWork>();
        ArgumentNullException.ThrowIfNull(unitOfWork);
        return unitOfWork;
    }

    protected static void RunCmd(
        IAppProgram app
        , string cmd)
    {
        if(cmd.Contains(" ") == false)
            app.Main(cmd);
        else 
            app.Main(cmd.Split(' '));
    }   
}
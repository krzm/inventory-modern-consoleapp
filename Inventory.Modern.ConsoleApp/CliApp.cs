using Config.Wrapper;
using DIHelper;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class CliApp
{
    private IDependencySuite? suite;
    private IAppProgram? app;

    public IDependencySuite? Suite => suite;
    public IAppProgram? App => app;

    public void CreateApp()
    {
         var unity = new UnityContainer()
            .AddExtension(new Diagnostic());
        var serviceSuite = new ServiceSuite(unity);
        serviceSuite.Register();
        suite = new SuiteConfig(
            unity.Resolve<IConfigReader>())
                .GetSuite(unity);
        IBootstraper booter = new Bootstraper(suite);
        booter.CreateApp();
        app = booter.App;
    }

    public void RunApp(params string[] args)
    {  
        ArgumentNullException.ThrowIfNull(app);
        app.Main("category");
    }
}
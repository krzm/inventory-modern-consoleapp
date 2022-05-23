using Config.Wrapper;
using DIHelper;
using Inventory.Modern.ConsoleApp;
using Unity;

var unity = new UnityContainer()
    .AddExtension(new Diagnostic());
var serviceSuite = new InventoryServiceSuite(unity);
serviceSuite.Register();
var suite = new InventorySuiteConfig(
    unity.Resolve<IConfigReader>())
        .GetSuite(unity);
IBootstraper booter = new Bootstraper(suite);
booter.Boot(args);
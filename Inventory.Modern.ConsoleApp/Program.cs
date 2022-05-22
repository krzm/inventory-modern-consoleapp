using DIHelper;
using Inventory.Modern.ConsoleApp;
using Unity;

IBootstraper booter = new Bootstraper(
    new UnityDependencySuite(
        new UnityContainer()
            .AddExtension(new Diagnostic())));
booter.Boot(args);
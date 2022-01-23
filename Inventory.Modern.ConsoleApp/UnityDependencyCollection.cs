using CLI.Core;
using Inventory.Modern.Lib;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class UnityDependencyCollection : CLI.Core.Lib.UnityDependencyCollection
{
    public UnityDependencyCollection(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterDatabase() =>
        RegisterDependencyProvider<AppDatabase>();

    protected override void RegisterConsoleOutput() =>
        RegisterDependencyProvider<AppOutput>();

    protected override void RegisterDataMappings() =>
        RegisterDependencyProvider<AppMappings>();

    protected override void RegisterCommands()
    {
        RegisterDependencyProvider<AppCommands>();
    }

    protected override void RegisterProgram() =>
        Container.RegisterSingleton<IAppProgram, AppProgram>();
}
using CRUDCommandHelper;
using DIHelper.Unity;
using Inventory.Modern.Lib;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class AppCommands 
    : UnityDependencySet
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<IReadCommand<ItemArgFilter>, ItemReadCommand>();
        Container.RegisterSingleton<IReadCommand<ItemCategoryArgFilter>, ItemCategoryReadCommand>();
        Container.RegisterSingleton<IReadCommand<ItemDetailArgFilter>, ItemDetailReadCommand>();
        Container.RegisterSingleton<IReadCommand<ItemImageArgFilter>, ItemImageReadCommand>();
        Container.RegisterSingleton<IReadCommand<StockArgFilter>, StockReadCommand>();
        Container.RegisterSingleton<IReadCommand<StockDetailArgFilter>, StockDetailReadCommand>();

        Container.RegisterSingleton<IInsertCommand<ItemArg>, ItemInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<ItemCategoryArg>, ItemCategoryInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<ItemDetailArg>, ItemDetailInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<ItemImageArg>, ItemImageInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<StockArg>, StockInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<StockDetailArg>, StockDetailInsertCommand>();

        Container.RegisterSingleton<IUpdateCommand<ItemArgUpdate>, ItemUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<ItemCategoryArgUpdate>, ItemCategoryUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<ItemDetailArgUpdate>, ItemDetailUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<ItemImageArgUpdate>, ItemImageUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<StockArgUpdate>, StockUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<StockDetailArgUpdate>, StockDetailUpdateCommand>();
    }
}
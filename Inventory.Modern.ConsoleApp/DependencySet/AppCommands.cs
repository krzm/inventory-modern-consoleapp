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
        Container
            .RegisterSingleton<IReadCommand<ItemArgFilter>, ItemReadCommand>()
            .RegisterSingleton<IReadCommand<ItemCategoryArgFilter>, ItemCategoryReadCommand>()
            .RegisterSingleton<IReadCommand<ItemDetailArgFilter>, ItemDetailReadCommand>()
            .RegisterSingleton<IReadCommand<ItemImageArgFilter>, ItemImageReadCommand>()
            .RegisterSingleton<IReadCommand<StockArgFilter>, StockReadCommand>()
            .RegisterSingleton<IReadCommand<StockDetailArgFilter>, StockDetailReadCommand>()

            .RegisterSingleton<IInsertCommand<ItemArg>, ItemInsertCommand>()
            .RegisterSingleton<IInsertCommand<ItemCategoryArg>, ItemCategoryInsertCommand>()
            .RegisterSingleton<IInsertCommand<ItemDetailArg>, ItemDetailInsertCommand>()
            .RegisterSingleton<IInsertCommand<ItemImageArg>, ItemImageInsertCommand>()
            .RegisterSingleton<IInsertCommand<StockArg>, StockInsertCommand>()
            .RegisterSingleton<IInsertCommand<StockDetailArg>, StockDetailInsertCommand>()

            .RegisterSingleton<IUpdateCommand<ItemArgUpdate>, ItemUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<ItemCategoryArgUpdate>, ItemCategoryUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<ItemDetailArgUpdate>, ItemDetailUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<ItemImageArgUpdate>, ItemImageUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<StockArgUpdate>, StockUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<StockDetailArgUpdate>, StockDetailUpdateCommand>();
    }
}
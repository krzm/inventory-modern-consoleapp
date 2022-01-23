using DataToTable;
using Inventory.Modern.Lib;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class AppOutput : CLI.Core.Lib.AppOutput
{
    public AppOutput(
        IUnityContainer container)
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container.RegisterSingleton<IColumnCalculator<Data.Item>, ColumnCalculator<Data.Item>>();
        Container.RegisterSingleton<IColumnCalculator<Data.ItemCategory>, ColumnCalculator<Data.ItemCategory>>();
        Container.RegisterSingleton<IColumnCalculator<Data.ItemDetail>, ColumnCalculator<Data.ItemDetail>>();
        Container.RegisterSingleton<IColumnCalculator<Data.ItemImage>, ColumnCalculator<Data.ItemImage>>();
        Container.RegisterSingleton<IColumnCalculator<Data.Stock>, ColumnCalculator<Data.Stock>>();
        Container.RegisterSingleton<IColumnCalculator<Data.StockDetail>, ColumnCalculator<Data.StockDetail>>();
    }

    protected override void RegisterTableProviders()
    {
        Container.RegisterSingleton<IDataToText<Data.Item>, ItemTable>();
        Container.RegisterSingleton<IDataToText<Data.ItemCategory>, ItemCategoryTable>();
        Container.RegisterSingleton<IDataToText<Data.ItemDetail>, ItemDetailTable>();
        Container.RegisterSingleton<IDataToText<Data.ItemImage>, ItemImageTable>();
        Container.RegisterSingleton<IDataToText<Data.Stock>, StockTable>();
        Container.RegisterSingleton<IDataToText<Data.StockDetail>, StockDetailTable>();
    }
}
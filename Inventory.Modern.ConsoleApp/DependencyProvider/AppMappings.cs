using AutoMapper;
using Inventory.Modern.Lib;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class AppMappings 
    : DIHelper.Unity.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<ItemArg, Data.Item>();
            cfg.CreateMap<ItemCategoryArg, Data.ItemCategory>();
            cfg.CreateMap<ItemDetailArg, Data.ItemDetail>();
            cfg.CreateMap<ItemImageArg, Data.ItemImage>();
            cfg.CreateMap<StockArg, Data.Stock>();
            cfg.CreateMap<StockDetailArg, Data.StockDetail>();

            cfg.CreateMap<ItemArgUpdate, Data.ItemUpdate>();
            cfg.CreateMap<ItemCategoryArgUpdate, Data.ItemCategoryUpdate>();
            cfg.CreateMap<ItemDetailArgUpdate, Data.ItemDetailUpdate>();
            cfg.CreateMap<ItemImageArgUpdate, Data.ItemImageUpdate>();
            cfg.CreateMap<StockArgUpdate, Data.StockUpdate>();
            cfg.CreateMap<StockDetailArgUpdate, Data.StockDetailUpdate>();
        });
        return config; 
    }
}
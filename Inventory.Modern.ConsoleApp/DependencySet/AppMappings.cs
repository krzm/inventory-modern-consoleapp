using AutoMapper;
using Inventory.Data;
using Inventory.Modern.Lib;
using Unity;

namespace Inventory.Modern.ConsoleApp;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() =>
        new (
        c => 
        {
            c.CreateMap<ItemArg, Item>();
            c.CreateMap<ItemCategoryArg, ItemCategory>();
            c.CreateMap<ItemDetailArg, ItemDetail>();
            c.CreateMap<ItemImageArg, ItemImage>();
            c.CreateMap<StockArg, Stock>();
            c.CreateMap<StockDetailArg, StockDetail>();

            c.CreateMap<ItemArgUpdate, ItemUpdate>();
            c.CreateMap<ItemCategoryArgUpdate, ItemCategoryUpdate>();
            c.CreateMap<ItemDetailArgUpdate, ItemDetailUpdate>();
            c.CreateMap<ItemImageArgUpdate, ItemImageUpdate>();
            c.CreateMap<StockArgUpdate, StockUpdate>();
            c.CreateMap<StockDetailArgUpdate, StockDetailUpdate>();
        });
}
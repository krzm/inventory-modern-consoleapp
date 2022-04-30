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
            c.CreateMap<ItemInsertArg, Item>();
            c.CreateMap<CategoryArg, Category>();
            c.CreateMap<SizeArg, Size>();
            c.CreateMap<ImageArg, Image>();
            c.CreateMap<StockArg, Stock>();

            c.CreateMap<ItemArgUpdate, ItemUpdate>();
            c.CreateMap<CategoryArgUpdate, CategoryUpdate>();
            c.CreateMap<SizeArgUpdate, SizeUpdate>();
            c.CreateMap<ImageArgUpdate, ImageUpdate>();
            c.CreateMap<StockArgUpdate, StockUpdate>();
        });
}
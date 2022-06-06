using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class StockCountCommands
    : InventoryCommands
{
    protected const string MainCommand = "stockcount";
    private readonly IInsertCommand<StockCountInsertArgs> insertCommand;

    public StockCountCommands(
        IInsertCommand<StockCountInsertArgs> insertCommand
        , IConfigReader config)
            : base(config)
    {
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
    }

    [Command(InsertCommand)]
    public void Insert(StockCountInsertArgs model)
    {
        insertCommand.Insert(model);
    }
}
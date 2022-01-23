using CLI.Core.Lib;
using CommandDotNet;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class StockDetailCommands : InvCommands
{
    protected const string MainCommand = "stockdetail";

    private readonly IReadCommand<StockDetailArgFilter> readCommand;
    private readonly IInsertCommand<StockDetailArg> insertCommand;
    private readonly IUpdateCommand<StockDetailArgUpdate> updateCommand;

    public StockDetailCommands(
        IReadCommand<StockDetailArgFilter> readCommand
        , IInsertCommand<StockDetailArg> insertCommand
        , IUpdateCommand<StockDetailArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(StockDetailArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(StockDetailArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new StockDetailArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(StockDetailArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
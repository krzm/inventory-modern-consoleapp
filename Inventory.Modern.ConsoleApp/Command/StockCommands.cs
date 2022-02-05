using CommandDotNet;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class StockCommands : InvCommands
{
    protected const string MainCommand = "stock";

    private readonly IReadCommand<StockArgFilter> readCommand;
    private readonly IInsertCommand<StockArg> insertCommand;
    private readonly IUpdateCommand<StockArgUpdate> updateCommand;

    public StockCommands(
        IReadCommand<StockArgFilter> readCommand
        , IInsertCommand<StockArg> insertCommand
        , IUpdateCommand<StockArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(StockArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(StockArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new StockArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(StockArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
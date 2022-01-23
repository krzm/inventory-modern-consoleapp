using CLI.Core.Lib;
using CommandDotNet;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemDetailCommands : InvCommands
{
    protected const string MainCommand = "itemdetail";

    private readonly IReadCommand<ItemDetailArgFilter> readCommand;
    private readonly IInsertCommand<ItemDetailArg> insertCommand;
    private readonly IUpdateCommand<ItemDetailArgUpdate> updateCommand;

    public ItemDetailCommands(
        IReadCommand<ItemDetailArgFilter> readCommand
        , IInsertCommand<ItemDetailArg> insertCommand
        , IUpdateCommand<ItemDetailArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ItemDetailArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemDetailArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new ItemDetailArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ItemDetailArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
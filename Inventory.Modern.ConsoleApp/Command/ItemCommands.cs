using CLI.Core.Lib;
using CommandDotNet;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemCommands : InvCommands
{
    protected const string MainCommand = "item";

    private readonly IReadCommand<ItemArgFilter> readCommand;
    private readonly IInsertCommand<ItemArg> insertCommand;
    private readonly IUpdateCommand<ItemArgUpdate> updateCommand;

    public ItemCommands(
        IReadCommand<ItemArgFilter> readCommand
        , IInsertCommand<ItemArg> insertCommand
        , IUpdateCommand<ItemArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ItemArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new ItemArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ItemArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
using CLI.Core.Lib;
using CommandDotNet;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemImageCommands : InvCommands
{
    protected const string MainCommand = "itemimage";

    private readonly IReadCommand<ItemImageArgFilter> readCommand;
    private readonly IInsertCommand<ItemImageArg> insertCommand;
    private readonly IUpdateCommand<ItemImageArgUpdate> updateCommand;

    public ItemImageCommands(
        IReadCommand<ItemImageArgFilter> readCommand
        , IInsertCommand<ItemImageArg> insertCommand
        , IUpdateCommand<ItemImageArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ItemImageArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemImageArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new ItemImageArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ItemImageArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
using CLI.Core.Lib;
using CommandDotNet;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemCategoryCommands : InvCommands
{
    protected const string MainCommand = "itemcategory";

    private readonly IReadCommand<ItemCategoryArgFilter> readCommand;
    private readonly IInsertCommand<ItemCategoryArg> insertCommand;
    private readonly IUpdateCommand<ItemCategoryArgUpdate> updateCommand;

    public ItemCategoryCommands(
        IReadCommand<ItemCategoryArgFilter> readCommand
        , IInsertCommand<ItemCategoryArg> insertCommand
        , IUpdateCommand<ItemCategoryArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ItemCategoryArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemCategoryArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new ItemCategoryArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ItemCategoryArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
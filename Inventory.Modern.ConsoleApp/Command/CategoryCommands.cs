using CommandDotNet;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class CategoryCommands : InvCommands
{
    protected const string MainCommand = "category";

    private readonly IReadCommand<CategoryArgFilter> readCommand;
    private readonly IInsertCommand<CategoryArg> insertCommand;
    private readonly IUpdateCommand<CategoryArgUpdate> updateCommand;

    public CategoryCommands(
        IReadCommand<CategoryArgFilter> readCommand
        , IInsertCommand<CategoryArg> insertCommand
        , IUpdateCommand<CategoryArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(CategoryArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(CategoryArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new CategoryArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(CategoryArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
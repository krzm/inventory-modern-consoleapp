using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class CategoryCommands
    : InventoryCommands
{
    protected const string MainCommand = "category";
    private readonly IReadCommand<CategoryArgFilter> readCommand;
    private readonly IInsertCommand<CategoryInsertArgs> insertCommand;
    private readonly IUpdateCommand<CategoryArgUpdate> updateCommand;

    public CategoryCommands(
        IReadCommand<CategoryArgFilter> readCommand
        , IInsertCommand<CategoryInsertArgs> insertCommand
        , IUpdateCommand<CategoryArgUpdate> updateCommand
        , IConfigReader config)
            : base(config)
    {
        this.readCommand = readCommand;
        ArgumentNullException.ThrowIfNull(this.readCommand);
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        this.updateCommand = updateCommand;
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(CategoryArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(CategoryInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<CategoryArgFilter>(
            readCommand
            , new CategoryArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(CategoryArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange(GetReadTask());
    }
}
using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemCommands
    : InventoryCommands
{
    private const string MainCommand = "item";
    private readonly IReadCommand<ItemReadArg> readCommand;
    private readonly IInsertCommand<ItemInsertArgs> insertCommand;
    private readonly IUpdateCommand<ItemUpdateArg> updateCommand;

    public ItemCommands(
        IReadCommand<ItemReadArg> readCommand
        , IInsertCommand<ItemInsertArgs> insertCommand
        , IUpdateCommand<ItemUpdateArg> updateCommand
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
    public void Read(ItemReadArg model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<ItemReadArg>(
            readCommand
            , new ItemReadArg());
    }

    [Command(UpdateCommand)]
    public void Update(ItemUpdateArg model)
    {
        updateCommand.Update(model);
        ReadAfterChange(GetReadTask());
    }
}
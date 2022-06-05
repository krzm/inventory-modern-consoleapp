using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class SizeCommands : InventoryCommands
{
    protected const string MainCommand = "size";
    private readonly IReadCommand<SizeArgFilter> readCommand;
    private readonly IInsertCommand<SizeInsertArgs> insertCommand;
    private readonly IUpdateCommand<SizeArgUpdate> updateCommand;

    public SizeCommands(
        IReadCommand<SizeArgFilter> readCommand
        , IInsertCommand<SizeInsertArgs> insertCommand
        , IUpdateCommand<SizeArgUpdate> updateCommand
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
    public void Read(SizeArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(SizeInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<SizeArgFilter>(
            readCommand
            , new SizeArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(SizeArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange(GetReadTask());
    }
}
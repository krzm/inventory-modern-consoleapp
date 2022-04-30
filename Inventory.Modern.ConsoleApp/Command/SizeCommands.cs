using CommandDotNet;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class SizeCommands : InvCommands
{
    protected const string MainCommand = "size";

    private readonly IReadCommand<SizeArgFilter> readCommand;
    private readonly IInsertCommand<SizeArg> insertCommand;
    private readonly IUpdateCommand<SizeArgUpdate> updateCommand;

    public SizeCommands(
        IReadCommand<SizeArgFilter> readCommand
        , IInsertCommand<SizeArg> insertCommand
        , IUpdateCommand<SizeArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(SizeArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(SizeArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new SizeArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(SizeArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class StateCommands
    : InventoryCommands
{
    protected const string MainCommand = "state";
    private readonly IInsertCommand<StateInsertArgs> insertCommand;

    public StateCommands(
        IInsertCommand<StateInsertArgs> insertCommand
        , IConfigReader config)
            : base(config)
    {
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
    }

    [Command(InsertCommand)]
    public void Insert(StateInsertArgs model)
    {
        insertCommand.Insert(model);
    }
}
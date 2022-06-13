using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ContainerCommands
    : InventoryCommands
{
    private const string MainCommand = "container";
    //private readonly IReadCommand<ContainerReadArg> readCommand;
    private readonly IInsertCommand<ContainerInsertArgs> insertCommand;
    //private readonly IUpdateCommand<ContainerUpdateArg> updateCommand;

    public ContainerCommands(
        //IReadCommand<ContainerReadArg> readCommand
        IInsertCommand<ContainerInsertArgs> insertCommand
        //IUpdateCommand<ContainerUpdateArg> updateCommand
        , IConfigReader config)
            : base(config)
    {
        //this.readCommand = readCommand;
        //ArgumentNullException.ThrowIfNull(this.readCommand);
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        //this.updateCommand = updateCommand;
        //ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ContainerReadArg model)
    {
        //readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ContainerInsertArgs model)
    {
        insertCommand.Insert(model);
        //ReadAfterChange(GetReadTask());
    }

    // private Func<Task> GetReadTask()
    // {
    //     return GetReadTask<ContainerReadArg>(
    //         readCommand
    //         , new ContainerReadArg());
    // }

    [Command(UpdateCommand)]
    public void Update(ContainerUpdateArg model)
    {
        //updateCommand.Update(model);
        //ReadAfterChange(GetReadTask());
    }
}
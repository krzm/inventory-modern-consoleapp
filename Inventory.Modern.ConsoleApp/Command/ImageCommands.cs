using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ImageCommands
    : InventoryCommands
{
    protected const string MainCommand = "itemimage";
    private readonly IReadCommand<ImageArgFilter> readCommand;
    private readonly IInsertCommand<ImageInsertArgs> insertCommand;
    private readonly IUpdateCommand<ImageArgUpdate> updateCommand;

    public ImageCommands(
        IReadCommand<ImageArgFilter> readCommand
        , IInsertCommand<ImageInsertArgs> insertCommand
        , IUpdateCommand<ImageArgUpdate> updateCommand
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
    public void Read(ImageArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ImageInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<ImageArgFilter>(
            readCommand
            , new ImageArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ImageArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange(GetReadTask());
    }
}
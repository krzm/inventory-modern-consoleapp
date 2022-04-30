using CommandDotNet;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ImageCommands : InvCommands
{
    protected const string MainCommand = "itemimage";

    private readonly IReadCommand<ImageArgFilter> readCommand;
    private readonly IInsertCommand<ImageArg> insertCommand;
    private readonly IUpdateCommand<ImageArgUpdate> updateCommand;

    public ImageCommands(
        IReadCommand<ImageArgFilter> readCommand
        , IInsertCommand<ImageArg> insertCommand
        , IUpdateCommand<ImageArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;

        ArgumentNullException.ThrowIfNull(this.readCommand);
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        ArgumentNullException.ThrowIfNull(this.updateCommand);
    }

    [DefaultCommand()]
    public void Read(ImageArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ImageArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new ImageArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(ImageArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
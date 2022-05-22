using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class ItemCommands
    : InvCommands
{
    private const string MainCommand = "item";
    private const string ReadCmdAfterChangeConfigKey = "ReadCmdAfterChange";
    private readonly IReadCommand<ItemReadArg> readCommand;
    private readonly IInsertCommand<ItemInsertArg> insertCommand;
    private readonly IUpdateCommand<ItemUpdateArg> updateCommand;
    private readonly IConfigReader config;
    private CmdSettings? cmdSettings;

    public ItemCommands(
        IReadCommand<ItemReadArg> readCommand
        , IInsertCommand<ItemInsertArg> insertCommand
        , IUpdateCommand<ItemUpdateArg> updateCommand
        , IConfigReader config)
    {
        this.readCommand = readCommand;
        ArgumentNullException.ThrowIfNull(this.readCommand);
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        this.updateCommand = updateCommand;
        ArgumentNullException.ThrowIfNull(this.updateCommand);
        this.config = config;
        ArgumentNullException.ThrowIfNull(this.config);
        cmdSettings = config.GetConfigSection<CmdSettings>(nameof(CmdSettings));
        ArgumentNullException.ThrowIfNull(cmdSettings);
    }

    [DefaultCommand()]
    public void Read(ItemReadArg model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(ItemInsertArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        if (IsReadAfterChangeOff())
            return;
        readCommand.Read(new ItemReadArg());
    }

    private bool IsReadAfterChangeOff()
    {
        return cmdSettings == null || cmdSettings.ReadCmdAfterChange == false;
    }

    [Command(UpdateCommand)]
    public void Update(ItemUpdateArg model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}
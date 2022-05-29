using Config.Wrapper;
using CRUDCommandHelper;

namespace Inventory.Modern.ConsoleApp;

public abstract class InventoryCommands
{
    protected const string InsertCommand = "ins";
    protected const string UpdateCommand = "upd";
    protected const string ReadCmdAfterChangeConfigKey = "ReadCmdAfterChange";
    private readonly IConfigReader config;
    protected CmdSettings? CmdSettings;

    public InventoryCommands(
        IConfigReader config)
    {
        this.config = config;
        ArgumentNullException.ThrowIfNull(this.config);
        CmdSettings = config.GetConfigSection<CmdSettings>(nameof(ConsoleApp.CmdSettings));
        ArgumentNullException.ThrowIfNull(CmdSettings);
    }

    protected async void ReadAfterChange(Func<Task> readDelegateAsync)
    {
        if (IsReadAfterChangeOff())
            return;
        await readDelegateAsync();
    }

    private bool IsReadAfterChangeOff()
    {
        return CmdSettings == null || CmdSettings.ReadCmdAfterChange == false;
    }

    protected Func<Task> GetReadTask<TArgs>(
        IReadCommand<TArgs> readCommand
        , TArgs model)
    {
        return async () =>
            await Task.Run(
                () => readCommand.Read(model));
    }
}
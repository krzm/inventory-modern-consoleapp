﻿using CommandDotNet;
using Config.Wrapper;
using CRUDCommandHelper;
using Inventory.Modern.Lib;

namespace Inventory.Modern.ConsoleApp;

[Command(MainCommand)]
public class StockCommands
    : InventoryCommands
{
    protected const string MainCommand = "stock";
    private readonly IReadCommand<StockArgFilter> readCommand;
    private readonly IInsertCommand<StockInsertArgs> insertCommand;
    private readonly IUpdateCommand<StockArgUpdate> updateCommand;
    private readonly IStockContainerInsertCommand stockContainerInsertCommand;

    public StockCommands(
        IReadCommand<StockArgFilter> readCommand
        , IInsertCommand<StockInsertArgs> insertCommand
        , IUpdateCommand<StockArgUpdate> updateCommand
        , IStockContainerInsertCommand stockContainerInsertCommand
        , IConfigReader config)
            : base(config)
    {
        this.readCommand = readCommand;
        ArgumentNullException.ThrowIfNull(this.readCommand);
        this.insertCommand = insertCommand;
        ArgumentNullException.ThrowIfNull(this.insertCommand);
        this.updateCommand = updateCommand;
        ArgumentNullException.ThrowIfNull(this.updateCommand);
        this.stockContainerInsertCommand = stockContainerInsertCommand;
        ArgumentNullException.ThrowIfNull(this.stockContainerInsertCommand);
    }

    [DefaultCommand()]
    public void Read(StockArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(StockInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange(GetReadTask());
    }

    [Command("addcontainer")]
    public void InsertStockContainer(StockContainerInsertArgs model)
    {
        stockContainerInsertCommand.Insert(model.StockId, model.ContainerId);
        ReadAfterChange(GetReadTask());
    }

    private Func<Task> GetReadTask()
    {
        return GetReadTask<StockArgFilter>(
            readCommand
            , new StockArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(StockArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange(GetReadTask());
    }
}
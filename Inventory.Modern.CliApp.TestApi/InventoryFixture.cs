using Inventory.Data;
using Inventory.Modern.ConsoleApp;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventory.Modern.CliApp.TestApi;

public class InventoryFixture
    : StockCountTestApi
        , IDisposable
{
    public InventoryFixture()
    {
        Booter = GetBooter();
        Uow = GetUnitOfWork(Booter);
        Transaction = Uow.BeginTransaction();
    }

    public void Dispose()
    {
        Transaction.Rollback();
    }

    public InventoryBootstraper Booter { get; private set; }

    public IInventoryUnitOfWork Uow { get; private set; }

    public IDbContextTransaction Transaction { get; private set; }
}
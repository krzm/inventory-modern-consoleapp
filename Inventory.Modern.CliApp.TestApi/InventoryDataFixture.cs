using Inventory.Data;
using Inventory.Modern.ConsoleApp;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventory.Modern.CliApp.TestApi;

public class InventoryDataFixture
    : StockCountTestApi
        , IDisposable
{
    public InventoryDataFixture()
    {
        Booter = GetBooter();
        Uow = GetUnitOfWork(Booter);
        Transaction = Uow.BeginTransaction();
    }

    public void Dispose()
    {
        Transaction.Commit();
    }

    public InventoryBootstraper Booter { get; private set; }

    public IInventoryUnitOfWork Uow { get; private set; }

    public IDbContextTransaction Transaction { get; private set; }
}
using Inventory.Data;
using Inventory.Modern.ConsoleApp;
using Microsoft.EntityFrameworkCore.Storage;

namespace Inventory.Modern.CliApp.TestApi;

public class InventoryNoDataFixture
    : StockCountTestApi
        , IDisposable
{
    public InventoryNoDataFixture()
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
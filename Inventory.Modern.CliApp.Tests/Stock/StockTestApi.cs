using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public abstract class StockTestApi
    : ImageTestApi
{
    protected static IEnumerable<Stock>? GetStocks(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Stock?.Get();
    }

    protected static void AssertStockCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetStocks(repo)?.Count() == count);
    }

    protected static Stock GetStock(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetStocks(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertStock(
        Stock expected
        , Stock acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.ItemId == expected.ItemId);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.TagId == expected.TagId);
    }
}
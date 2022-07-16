using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class StockTestApi
    : ImageTestApi
{
    protected static IEnumerable<Stock>? GetStocks(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Stock?.Get();
    }

    public void AssertStockCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetStocks(repo)?.Count() == count);
    }

    public Stock GetStock(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetStocks(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertStock(
        Stock expected
        , Stock acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.ItemId == expected.ItemId);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.TagId == expected.TagId);
    }
}
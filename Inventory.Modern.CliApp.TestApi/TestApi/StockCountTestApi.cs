using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class StockCountTestApi
    : StateTestApi
{
    protected static IEnumerable<StockCount>? GetStockCounts(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.StockCount?.Get();
    }

    public void AssertStockCountCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetStockCounts(repo)?.Count() == count);
    }

    public StockCount GetStockCount(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetStockCounts(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
    
    public void AssertStockCount(
        StockCount expected
        , StockCount acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.StockId == expected.StockId);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.Count == expected.Count);
    }
}
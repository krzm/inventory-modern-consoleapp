using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class StateTestApi
    : StockTestApi
{
    protected static IEnumerable<State>? GetStates(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.State?.Get();
    }

    protected static void AssertState(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetStates(repo)?.Count() == count);
    }

    public State GetState(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetStates(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }
    
    protected static void AssertState(
        State expected
        , State acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.CategoryId == expected.CategoryId);
    }
}
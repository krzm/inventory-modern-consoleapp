using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public abstract class CategoryTestApi
    : InventoryCliTestApi
{
    protected static IEnumerable<Category>? GetData(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Category?.Get();
    }

    protected static void AssertCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetData(repo)?.Count() == count);
    }

    protected static Category GetItem(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetData(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertData(
        Category expected
        , Category acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
    }
}
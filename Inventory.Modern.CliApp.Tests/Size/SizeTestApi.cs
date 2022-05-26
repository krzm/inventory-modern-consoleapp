using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public abstract class SizeTestApi
    : InventoryCliTestApi
{
    protected static IEnumerable<Size>? GetData(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Size?.Get();
    }

    protected static void AssertCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetData(repo)?.Count() == count);
    }

    protected static Size GetItem(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetData(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertData(
        Size expected
        , Size acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Length == expected.Length);
        Assert.True(acctual?.Heigth == expected.Heigth);
        Assert.True(acctual?.Depth == expected.Depth);
    }
}
using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public abstract class SizeTestApi
    : CategoryTestApi
{
    protected static IEnumerable<Size>? GetSizes(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Size?.Get();
    }

    protected static void AssertSizeCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetSizes(repo)?.Count() == count);
    }

    protected static Size GetSize(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetSizes(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertSize(
        Size expected
        , Size acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Length == expected.Length);
        Assert.True(acctual?.Heigth == expected.Heigth);
        Assert.True(acctual?.Depth == expected.Depth);
    }
}
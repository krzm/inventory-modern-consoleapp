using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class SizeTestApi
    : CategoryTestApi
{
    protected static IEnumerable<Size>? GetSizes(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Size?.Get();
    }

    public void AssertSizeCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetSizes(repo)?.Count() == count);
    }

    public Size GetSize(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetSizes(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertSize(
        Size expected
        , Size acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Length == expected.Length);
        Assert.True(acctual?.Heigth == expected.Heigth);
        Assert.True(acctual?.Depth == expected.Depth);
    }
}
using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class ItemTestApi
    : SizeTestApi
{
    protected static IEnumerable<Item>? GetItems(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Item?.Get();
    }

    public void AssertItemCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetItems(repo)?.Count() == count);
    }

    public Item GetItem(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetItems(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertItem(
        Item expected
        , Item acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.CategoryId == expected.CategoryId);
        Assert.True(acctual?.SizeId == expected.SizeId);
    }
}
using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class CategoryTestApi
    : InventoryCliTestApi
{
    protected static IEnumerable<Category>? GetCategories(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Category?.Get();
    }

    protected static void AssertCategoryCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetCategories(repo)?.Count() == count);
    }

    protected static Category GetCategory(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetCategories(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertCategory(
        Category expected
        , Category acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
    }
}
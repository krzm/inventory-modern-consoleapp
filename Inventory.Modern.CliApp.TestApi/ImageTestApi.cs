using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class ImageTestApi
    : ItemTestApi
{
    protected static IEnumerable<Image>? GetImages(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Image?.Get();
    }

    protected static void AssertImageCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetCategories(repo)?.Count() == count);
    }

    public Image GetImage(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetImages(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertImage(
        Image expected
        , Image acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Path == expected.Path);
        Assert.True(acctual?.ItemId == expected.ItemId);
    }
}
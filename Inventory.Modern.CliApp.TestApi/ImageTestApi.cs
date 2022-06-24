using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class ImageTestApi
    : ContainerTestApi
{
    protected static IEnumerable<Image>? GetImages(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Image?.Get();
    }

    public void AssertImageCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetImages(repo)?.Count() == count);
    }

    public Image GetImage(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetImages(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertImage(
        Image expected
        , Image acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Path == expected.Path);
        Assert.True(acctual?.ItemId == expected.ItemId);
    }
}
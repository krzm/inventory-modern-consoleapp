using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public abstract class ContainerTestApi
    : ItemTestApi
{
    protected static IEnumerable<Container>? GetContainers(
        IInventoryUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Container?.Get();
    }

    protected static void AssertContainerCount(
        IInventoryUnitOfWork? repo
        , int count)
    {
        Assert.True(GetContainers(repo)?.Count() == count);
    }

    public Container GetContainer(
        IInventoryUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetContainers(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    protected static void AssertContainer(
        Container expected
        , Container acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
        Assert.True(acctual?.CategoryId == expected.CategoryId);
        Assert.True(acctual?.SizeId == expected.SizeId);
        Assert.True(acctual?.ParentId == expected.ParentId);
    }
}
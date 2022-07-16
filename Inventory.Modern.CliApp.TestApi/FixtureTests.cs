using Xunit;
using XUnit.Helper;

namespace Inventory.Modern.CliApp.TestApi;

[Collection("Serial1")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class FixtureTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public FixtureTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void Test01()
    {
        fixture.AssertCategoryCount(fixture.Uow, 0);
        fixture.AssertImageCount(fixture.Uow, 0);
        fixture.AssertItemCount(fixture.Uow, 0);
        fixture.AssertSizeCount(fixture.Uow, 0);
        fixture.AssertStockCount(fixture.Uow, 0);
    }

    [Fact]
    public void Test02()
    {
        fixture.AssertCategoryCount(fixture.Uow, 0);
        fixture.AssertImageCount(fixture.Uow, 0);
        fixture.AssertItemCount(fixture.Uow, 0);
        fixture.AssertSizeCount(fixture.Uow, 0);
        fixture.AssertStockCount(fixture.Uow, 0);
    }
}
using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class FixtureTests
    : IClassFixture<InventoryFixture>
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
}
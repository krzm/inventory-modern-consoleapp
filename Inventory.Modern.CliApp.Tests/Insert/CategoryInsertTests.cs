using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class CategoryInsertTests
    : IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public CategoryInsertTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(CategoryInsertData.Test01), MemberType= typeof(CategoryInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.AssertCategoryCount(fixture.Uow, 0);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertCategoryCount(fixture.Uow, 1);
        var data = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        fixture.AssertCategory(
            new Category 
            { 
                Name = "test"
                , Description = "test"
            }
            , data);
    }
}
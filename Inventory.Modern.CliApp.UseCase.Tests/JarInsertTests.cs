using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.UseCase.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class JarInsertTests
    : IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public JarInsertTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(JarData.Data), MemberType= typeof(JarData))]
    public void Test1(params string[] cmd
    )
    {

        fixture.RunCmd(fixture.Booter, cmd);
        //fixture.RunCmd(fixture.Booter, sizeCmd);
        //var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        //var size = fixture.GetSize(fixture.Uow, elementIndex: 0);
        //RunCmd(booter, $"item ins test test {category.Id} {size.Id}");
        //var item = GetItem(uow, 0);
        //RunCmd(booter, $"stock ins {item.Id} test");
        // AssertStockCount(uow, 1);
        // var data = GetStock(uow, elementIndex: 0);
        // AssertStock(
        //     new Stock 
        //     { 
        //         ItemId = item.Id
        //         , Description = "test"
        //     }
        //     , data!);
    }

    [Fact]
    public void Test2()
    {
        //fixture.RunCmd(fixture.Booter, cmd);
        //fixture.RunCmd(fixture.Booter, sizeCmd);
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var size = fixture.GetSize(fixture.Uow, elementIndex: 0);
        //RunCmd(booter, $"item ins test test {category.Id} {size.Id}");
        //var item = GetItem(uow, 0);
        //RunCmd(booter, $"stock ins {item.Id} test");
        // AssertStockCount(uow, 1);
        // var data = GetStock(uow, elementIndex: 0);
        // AssertStock(
        //     new Stock 
        //     { 
        //         ItemId = item.Id
        //         , Description = "test"
        //     }
        //     , data!);
    }
}
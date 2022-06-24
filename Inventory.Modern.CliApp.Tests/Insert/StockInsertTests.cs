using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class StockInsertTests
    : IClassFixture<InventoryNoDataFixture>
{
    private InventoryNoDataFixture fixture;

    public StockInsertTests(InventoryNoDataFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(StockInsertData.Test01), MemberType= typeof(StockInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(StockInsertData.Test02), MemberType= typeof(StockInsertData))]
    public void Test02(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(StockInsertData.Test03), MemberType= typeof(StockInsertData))]
    public void Test03(params string[] cmd)
    {
        fixture.AssertStockCount(fixture.Uow, 0);
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertStockCount(fixture.Uow, 1);
        var data = fixture.GetStock(fixture.Uow, elementIndex: 0);
        fixture.AssertStock(
            new Stock 
            { 
                ItemId = item.Id
                , Description = "test"
            }
            , data!);
    }

    private void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    private int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }
}
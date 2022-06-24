using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class ItemInsertTests
    : IClassFixture<InventoryNoDataFixture>
{
    private InventoryNoDataFixture fixture;

    public ItemInsertTests(InventoryNoDataFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ItemInsertData.Test01), MemberType= typeof(ItemInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(ItemInsertData.Test02), MemberType= typeof(ItemInsertData))]
    public void Test02(params string[] cmd)
    {
        fixture.AssertItemCount(fixture.Uow, 0);
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var size = fixture.GetSize(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        SetValue(command, "sizeid", size.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertItemCount(fixture.Uow, 1);
        var data = fixture.GetItem(fixture.Uow, elementIndex: 0);
        fixture.AssertItem(
            new Item 
            { 
                Name = "test"
                , Description = "test"
                , CategoryId = category.Id
                , SizeId = size.Id
            }
            , data);
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
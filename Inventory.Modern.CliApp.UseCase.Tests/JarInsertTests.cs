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
    [MemberData(nameof(JarData.Level1), MemberType= typeof(JarData))]
    public void TestLevel1(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(JarData.Level2), MemberType= typeof(JarData))]
    public void TestLevel2(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var size = fixture.GetSize(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        SetValue(command, "sizeid", size.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Level3), MemberType= typeof(JarData))]
    public void TestLevel3(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var image = fixture.GetImage(fixture.Uow, elementIndex: 0);
    }

    [Theory]
    [MemberData(nameof(JarData.Level4), MemberType= typeof(JarData))]
    public void TestLevel4(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Level5), MemberType= typeof(JarData))]
    public void TestLevel5(params string[] cmd)
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "stockid", stock.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var stockcount = fixture.GetStockCount(fixture.Uow, elementIndex: 0);
    }

    private int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }

    private void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }
}
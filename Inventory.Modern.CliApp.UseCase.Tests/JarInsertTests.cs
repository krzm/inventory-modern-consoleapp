using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.UseCase.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class JarInsertTests
    : IClassFixture<InventoryNoDataFixture>
{
    private InventoryNoDataFixture fixture;

    public JarInsertTests(InventoryNoDataFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(JarData.Test01), MemberType= typeof(JarData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(JarData.Test02), MemberType= typeof(JarData))]
    public void Test02(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var size = fixture.GetSize(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        SetValue(command, "sizeid", size.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Test03), MemberType= typeof(JarData))]
    public void Test03(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var image = fixture.GetImage(fixture.Uow, elementIndex: 0);
    }

    [Theory]
    [MemberData(nameof(JarData.Test04), MemberType= typeof(JarData))]
    public void Test04(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Test05), MemberType= typeof(JarData))]
    public void Test05(params string[] cmd)
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "stockid", stock.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var stockcount = fixture.GetStockCount(fixture.Uow, elementIndex: 0);
    }

    [Theory]
    [MemberData(nameof(JarData.Test06), MemberType= typeof(JarData))]
    public void Test06(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(JarData.Test07), MemberType= typeof(JarData))]
    public void Test07(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 1);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Test08), MemberType= typeof(JarData))]
    public void Test08(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 1);
        var container = fixture.GetContainer(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        SetValue(command, "parentid", container.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarData.Test09), MemberType= typeof(JarData))]
    public void Test09(params string[] cmd)
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        var container = fixture.GetContainer(fixture.Uow, elementIndex: 1);
        var command = new List<string>(cmd);
        SetValue(command, "stockid", stock.Id.ToString());
        SetValue(command, "containerid", container.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Fact]
    public void Test10()
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        Assert.True(stock.Containers?.ElementAt(0).Name == "Shelf X");
        Assert.True(stock.Containers?.ElementAt(0).Parent?.Name == "Storage Cabinet");
    }

    [Theory]
    [MemberData(nameof(JarData.Test11), MemberType= typeof(JarData))]
    public void Test11(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Fact]
    public void Test12()
    {
        var state = fixture.GetState(fixture.Uow, elementIndex: 0);
        Assert.True(state.Name == "ToDo");
        Assert.True(state.Description == "Sort lids");
    }

    [Theory]
    [MemberData(nameof(JarData.Test13), MemberType= typeof(JarData))]
    public void Test13(params string[] cmd)
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        var state = fixture.GetState(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "stockid", stock.Id.ToString());
        SetValue(command, "stateid", state.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Fact]
    public void Test14()
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        Assert.True(stock.States?.ElementAt(0).Name == "ToDo");
        Assert.True(stock.States?.ElementAt(0).Description == "Sort lids");
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
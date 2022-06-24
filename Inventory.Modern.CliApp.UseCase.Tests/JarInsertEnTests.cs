using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.UseCase.Tests;

[Collection("Serial3")]
[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1000:Test classes must be public", Justification = "<Pending>")]
class JarInsertEnTests
    : IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public JarInsertEnTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test01), MemberType = typeof(JarDataEn))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test02), MemberType = typeof(JarDataEn))]
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
    [MemberData(nameof(JarDataEn.Test03), MemberType = typeof(JarDataEn))]
    public void Test03(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var image = fixture.GetImage(fixture.Uow, elementIndex: 0);
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test04), MemberType = typeof(JarDataEn))]
    public void Test04(params string[] cmd)
    {
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test05), MemberType = typeof(JarDataEn))]
    public void Test05(params string[] cmd)
    {
        var stock = fixture.GetStock(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "stockid", stock.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var stockcount = fixture.GetStockCount(fixture.Uow, elementIndex: 0);
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test06), MemberType = typeof(JarDataEn))]
    public void Test06(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test07), MemberType = typeof(JarDataEn))]
    public void Test07(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 1);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(JarDataEn.Test08), MemberType = typeof(JarDataEn))]
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
    [MemberData(nameof(JarDataEn.Test09), MemberType = typeof(JarDataEn))]
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
    [MemberData(nameof(JarDataEn.Test11), MemberType = typeof(JarDataEn))]
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
    [MemberData(nameof(JarDataEn.Test13), MemberType = typeof(JarDataEn))]
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
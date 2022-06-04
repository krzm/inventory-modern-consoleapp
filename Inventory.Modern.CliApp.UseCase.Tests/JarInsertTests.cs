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
        command.Add(category.Id.ToString());
        command.Add($"-s");
        command.Add(size.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
    }
}
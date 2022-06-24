using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

[TestCaseOrderer("Inventory.Modern.CliApp.TestApi.AlphabeticalOrderer", "Inventory.Modern.CliApp.TestApi")]
public class SizeInsertTests
    : IClassFixture<InventoryNoDataFixture>
{
    private InventoryNoDataFixture fixture;

    public SizeInsertTests(InventoryNoDataFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(SizeInsertData.Test01), MemberType= typeof(SizeInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.AssertSizeCount(fixture.Uow, 0);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertSizeCount(fixture.Uow, 1);
        var data = fixture.GetSize(fixture.Uow, elementIndex: 0);
        fixture.AssertSize(
            new Size 
            { 
                Length = 1
                , Heigth = 1
                , Depth = 1
            }
            , data);
    }
}
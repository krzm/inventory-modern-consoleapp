using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Inventory.Modern.CliApp.Tests.Insert.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Modern.CliApp.Tests;

[Collection("Serial2")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class SizeInsertTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public SizeInsertTests(InventoryFixture fixture)
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
using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Inventory.Modern.CliApp.Tests.Insert.Data;
using Xunit;
using XUnit.Helper;

namespace Inventory.Modern.CliApp.Tests;

[Collection("Serial2")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class ImageInsertTests
    : OrderTest
    , IClassFixture<InventoryFixture>
{
    private InventoryFixture fixture;

    public ImageInsertTests(InventoryFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(ImageInsertData.Test01), MemberType= typeof(ImageInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(ImageInsertData.Test02), MemberType= typeof(ImageInsertData))]
    public void Test02(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
    }

    [Theory]
    [MemberData(nameof(ImageInsertData.Test03), MemberType= typeof(ImageInsertData))]
    public void Test03(params string[] cmd)
    {
        fixture.AssertImageCount(fixture.Uow, 0);
        var item = fixture.GetItem(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "itemid", item.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertImageCount( fixture.Uow, 1);
        var data =  fixture.GetImage( fixture.Uow, elementIndex: 0);
        var path = @"C:\kmazanek@gmail.com\Image\People\IMG_20210211_163337.jpg";
        fixture.AssertImage(
            new Image 
            { 
                Path = path
                , ItemId = item.Id
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
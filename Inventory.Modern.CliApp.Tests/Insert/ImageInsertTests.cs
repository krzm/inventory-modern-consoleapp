using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public class ImageInsertTests
    : ImageTestApi
{
    [Fact]
    public async void Test_Correct_Data_Insert()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            AssertImageCount(uow, 0);
            RunCmd(booter, "category", "ins", "test", "test");
            RunCmd(booter, "size", "ins", "1", "2", "-l", "1", "-e", "1", "-d", "1");
            var category = GetCategory(uow, elementIndex: 0);
            var size = GetSize(uow, elementIndex: 0);
            RunCmd(booter, "item", "ins", "test", "-d", "test", category.Id.ToString(), "-s", size.Id.ToString());
            var item = GetItem(uow, 0);
            var path = @"C:\kmazanek@gmail.com\Image\People\IMG_20210211_163337.jpg";
            RunCmd(booter, "itemimage", "ins", item.Id.ToString(), path);
            AssertImageCount(uow, 1);
            var data = GetImage(uow, elementIndex: 0);
            AssertImage(
                new Image 
                { 
                    Path = path
                    , ItemId = item.Id
                }
                , data);
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}
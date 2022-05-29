using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public class StockInsertTests
    : StockTestApi
{
    [Fact]
    public async void Test_Correct_Data_Insert()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            AssertStockCount(uow, 0);
            RunCmd(booter, "category ins test test");
            RunCmd(booter, "size ins 1 1 1");
            var category = GetCategory(uow, elementIndex: 0);
            var size = GetSize(uow, elementIndex: 0);
            RunCmd(booter, $"item ins test test {category.Id} {size.Id}");
            var item = GetItem(uow, 0);
            RunCmd(booter, $"stock ins {item.Id} test");
            AssertStockCount(uow, 1);
            var data = GetStock(uow, elementIndex: 0);
            AssertStock(
                new Stock 
                { 
                    ItemId = item.Id
                    , Description = "test"
                }
                , data!);
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}
using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public class CategoryInsertTests
    : CategoryTestApi
{
    [Fact]
    public async void Test_Correct_Data_Insert()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            AssertCount(uow, 0);
            RunCmd(booter.App!, "category ins test test");
            AssertCount(uow, 1);
            var data = GetItem(uow, elementIndex: 0);
            AssertData(
                new Category 
                { 
                    Name = "test"
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
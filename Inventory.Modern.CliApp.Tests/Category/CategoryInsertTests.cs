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
            AssertCategoryCount(uow, 0);
            RunCmd(booter, "category ins test test");
            AssertCategoryCount(uow, 1);
            var data = GetCategory(uow, elementIndex: 0);
            AssertCategory(
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
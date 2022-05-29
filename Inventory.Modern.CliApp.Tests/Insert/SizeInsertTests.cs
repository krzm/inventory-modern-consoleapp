using Inventory.Data;
using Inventory.Modern.CliApp.TestApi;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public class SizeInsertTests
    : SizeTestApi
{
    [Fact]
    public async void Test_Correct_Data_Insert()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            AssertSizeCount(uow, 0);
            RunCmd(booter, "size ins 1 1 1");
            AssertSizeCount(uow, 1);
            var data = GetSize(uow, elementIndex: 0);
            AssertSize(
                new Size 
                { 
                    Length = 1
                    , Heigth = 1
                    , Depth = 1
                }
                , data!);
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}
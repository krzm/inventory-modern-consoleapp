using Inventory.Data;
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
            AssertCount(uow, 0);
            RunCmd(booter.App!, "size ins 1 1 1");
            AssertCount(uow, 1);
            var data = GetItem(uow, elementIndex: 0);
            AssertData(
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
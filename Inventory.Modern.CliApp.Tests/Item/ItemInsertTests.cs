using System.Diagnostics;
using Inventory.Data;
using Xunit;

namespace Inventory.Modern.CliApp.Tests;

public class ItemInsertTests
    : ItemTestApi
{
    [Fact]
    public async void Test_Correct_Data_Insert()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            AssertItemCount(uow, 0);
            RunCmd(booter, "category ins test test");
            RunCmd(booter, "size ins 1 1 1");
            var category = GetCategory(uow, elementIndex: 0);
            var size = GetSize(uow, elementIndex: 0);
            RunCmd(booter, $"item ins test test {category.Id} {size.Id}");
            AssertItemCount(uow, 1);
            var data = GetItem(uow, elementIndex: 0);
            AssertItem(
                new Item 
                { 
                    Name = "test"
                    , Description = "test"
                    , CategoryId = category.Id
                    , SizeId = size.Id
                }
                , data!);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}
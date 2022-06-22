using Xunit;

namespace Inventory.Modern.CliApp.TestApi;

public class TestApiTests
    : CategoryTestApi
{
    [Fact]
    public async void Test_Correct_TestApi_Setup()
    {
        var booter = GetBooter();
        var uow = GetUnitOfWork(booter);

        var transaction = await uow.BeginTransactionAsync();
        try
        {
            
        }
        finally
        {
            await transaction.RollbackAsync();
        }
    }
}
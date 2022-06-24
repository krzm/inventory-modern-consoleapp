namespace Inventory.Modern.CliApp.Tests.Insert.Data;

public class StockInsertData
{
    public static IEnumerable<object[]> Test01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "test", "test" }
        };

    public static IEnumerable<object[]> Test02 =>
        new List<object[]>
        {
            new object[] { "item", "ins", "test", "-d", "test", "categoryid" }
        };

    public static IEnumerable<object[]> Test03 =>
        new List<object[]>
        {
            new object[] { "stock", "ins", "itemid", "-d", "test" }
        };
}
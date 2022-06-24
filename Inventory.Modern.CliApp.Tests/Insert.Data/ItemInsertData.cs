namespace Inventory.Modern.CliApp.Tests.Insert.Data;

public class ItemInsertData
{
    public static IEnumerable<object[]> Test01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "test", "test" }
            , new object[] { "size", "ins", "1", "2", "-l", "1", "-e", "1", "-d", "1" }
        };

    public static IEnumerable<object[]> Test02 =>
        new List<object[]>
        {
            new object[] { "item", "ins", "test", "-d", "test", "categoryid", "-s", "sizeid" }
        };
}
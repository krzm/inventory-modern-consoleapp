namespace Inventory.Modern.CliApp.Tests.Insert.Data;

public class SizeInsertData
{
    public static IEnumerable<object[]> Test01 =>
        new List<object[]>
        {
            new object[] { "size", "ins", "1", "2", "-l", "1", "-e", "1", "-d", "1" }
        };
}
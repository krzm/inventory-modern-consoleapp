namespace Inventory.Modern.CliApp.Tests.Insert.Data;

public class ImageInsertData
{
    private const string Path = @"C:\kmazanek@gmail.com\Image\People\IMG_20210211_163337.jpg";

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
            new object[] { "itemimage", "ins", "itemid", Path }
        };
}
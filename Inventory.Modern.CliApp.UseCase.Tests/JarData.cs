namespace Inventory.Modern.CliApp.UseCase.Tests;

public class JarData
{
    public static IEnumerable<object[]> Level1 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "Jar", "Cylindrical container made of glass with lid" }
            , new object[] { "size", "ins", "1", "2", "-e", "20", "-i", "10", "-v", "0.9", "-s", "my larger jars collection" }
        };

    public static IEnumerable<object[]> Level2 =>
        new List<object[]>
        {
            new object[] { "item", "ins", "Jar 0.9l", "-d", "Biggest jar size in my jar collection", "categoryid", "-s", "sizeid" }
        };

    public static IEnumerable<object[]> Level3 =>
        new List<object[]>
        {
            new object[] { "itemimage", "ins", "itemid", @"C:\kmazanek@gmail.com\Image\Inventory\BigJar.jpg", "-d", "Big Jar foto" }
        };
    
    public static IEnumerable<object[]> Level4 =>
        new List<object[]>
        {
            new object[] { "stock", "ins", "itemid", "-d", "Collection of empty big jars" }
        };
    
    public static IEnumerable<object[]> Level5 =>
        new List<object[]>
        {
            new object[] { "stockcount", "ins", "stockid", "22", "-d", "All empty" }
        };

    public static IEnumerable<object[]> Level6 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "Furniture", "Big storage units" }
        };
    
    public static IEnumerable<object[]> Level7 =>
        new List<object[]>
        {
            new object[] { "container", "ins", "Storage Cabinet", "categoryid" }
        };
    
    public static IEnumerable<object[]> Level8 =>
        new List<object[]>
        {
            new object[] { "container", "ins", "Shelf X", "categoryid", "-p", "parentid" }
        };

    public static IEnumerable<object[]> Level9 =>
        new List<object[]>
        {
            new object[] { "stock", "addcontainer", "stockid", "containerid" }
        };
    
    public static IEnumerable<object[]> Level10 =>
        new List<object[]>
        {
            new object[] { "state", "ins", "Empty", "categoryid" }
        };
}
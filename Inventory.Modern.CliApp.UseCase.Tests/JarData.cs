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
            new object[] { "item", "ins", "Jar 0.9l", "-d", "Biggest jar size in my jar collection"}
        };
}
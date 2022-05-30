namespace Inventory.Modern.CliApp.UseCase.Tests;

public class JarData
{
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "category", "ins", "Jar", "Cylindrical container made of glass with lid"}
            , 
            new object[] { "size", "ins", "1", "1", "1" }
        };
}
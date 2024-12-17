namespace Db;

public class PrioritiesConverter
{
    public static string ConvertPriorities(IEnumerable<int> priorities)
    {
        return string.Join(", ", priorities);
    }
}
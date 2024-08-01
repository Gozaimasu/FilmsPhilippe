namespace ConsoleApp2;

public static class Functional
{
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var item in values) action(item);
    }
}

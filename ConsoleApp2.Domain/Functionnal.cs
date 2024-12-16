namespace ConsoleApp2.Domain;

public static class Functional
{
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var item in values) action(item);
    }
}

namespace ConsoleApp2.Models;

public record YearType(uint Value);

public static class Year
{
    public static YearType? Create(uint value) => new(value);
    public static YearType? Create(int value) =>
        value < 0 ? null : new((uint)value);
}
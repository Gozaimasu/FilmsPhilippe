using System.Data.Common;

namespace ConsoleApp2;

public static class DbDataReaderExtensions
{
    public static string? GetNullableString(this DbDataReader reader, string name)
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.GetValue(reader.GetOrdinal(name)) as string;
    }

    public static string? GetNullableString(this DbDataReader reader, int ordinal)
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.GetValue(ordinal) as string;
    }
}

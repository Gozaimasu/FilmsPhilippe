using System.Data.Common;

namespace ConsoleApp2.Infrastructure.MSAccess.Extensions;

public static class DbDataReaderExtensions
{
    public static string? GetNullableString(this DbDataReader reader, string name) =>
        reader.GetNullableString(reader.GetOrdinal(name));

    public static string? GetNullableString(this DbDataReader reader, int ordinal) =>
        reader.GetValue(ordinal) as string;
}

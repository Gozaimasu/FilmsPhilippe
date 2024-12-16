using ConsoleApp2.Domain.Models;

namespace ConsoleApp2.Processes;

public delegate string FormatName(NameType name);

public delegate string FormatNamesList(NameType[] names);
public delegate string FormatNameListExt(FormatName format, NameType[] names);

public static class FormatNameDefaults
{
    public static FormatName FormatFullName => name => name.Map(
        fullname => $"{fullname.FirstName} {fullname.LastName}",
        mononym => mononym.Name);
    public static FormatName FormatInitials => name => name.Map(
        fullname => $"{fullname.FirstName[..1]}. {fullname.LastName[..1]}.",
        mononym => $"{mononym.Name[..1]}.");
    public static FormatName FormatAcademic => name => name.Map(
        fullname => $"{fullname.LastName}, {fullname.FirstName[..1]}.",
        mononym => mononym.Name);
}

public static class FormatNameListDefaults
{
    public static FormatNameListExt CommaSeparatedNames => (format, names) =>
        string.Join(", ", names.Select(format.Invoke));
}

public static class FormatNameListExtensions
{
    public static FormatNamesList Apply(this FormatNameListExt formatter, FormatName nameFormater) =>
        names => formatter(nameFormater, names);
}

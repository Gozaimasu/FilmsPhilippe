namespace FilmsPhilippe.Application;

public static class Name
{
    public static NameType? Create(string firstName, string lastName) =>
        string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ? null
        : new FullNameType(firstName, lastName);

    public static NameType? Create(string mononyme) =>
        string.IsNullOrWhiteSpace(mononyme) ? null : new MononymeType(mononyme);

    public static NameType[]? CreateMany(params NameType?[] names) =>
        names.Any(name => name is null) ? null : (NameType[]?)names!;
}

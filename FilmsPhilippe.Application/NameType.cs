namespace FilmsPhilippe.Application;

public abstract record NameType;

internal record FullNameType(string FirstName, string LastName) : NameType;
internal record MononymeType(string Name) : NameType;


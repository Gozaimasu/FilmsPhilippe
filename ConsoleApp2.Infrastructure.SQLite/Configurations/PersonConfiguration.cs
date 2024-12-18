using ConsoleApp2.Domain.Models;
using ConsoleApp2.Domain.Processes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp2.Infrastructure.SQLite.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<PersonType>
{
    public void Configure(EntityTypeBuilder<PersonType> builder)
    {
        builder.ToTable("Persons");

        builder
            .HasKey(a => a.Id);

        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(a => a.Name)
            .HasConversion(
                n => FormatNameDefaults.FormatFullName.Invoke(n),
                n => Name.Create(n)!);
        
        builder
            .Ignore(p => p.Movies);
    }
}
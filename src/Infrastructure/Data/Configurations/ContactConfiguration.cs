using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.EmailAddress)
                .Property(p => p.Value)
                .HasMaxLength(50)
                .HasColumnName("EmailAddress")
                .IsRequired();

            builder.OwnsOne(c => c.PhoneNumber)
                .Property(p => p.Value)
                .HasMaxLength(50)
                .HasColumnName("PhoneNumber")
                .IsRequired();

            builder.OwnsOne(c => c.FullName, f =>
            {
                f.WithOwner();

                f.Property(f => f.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("FirstName")
                    .IsRequired();

                f.Property(f => f.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("LastName")
                    .IsRequired();
            });

            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();

                a.Property(a => a.ZipCode)
                    .HasMaxLength(18)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");

                a.Property(a => a.Street)
                    .HasMaxLength(180)
                    .HasColumnName("Street")
                    .HasDefaultValue("");

                a.Property(a => a.State)
                    .HasColumnName("State")
                    .HasMaxLength(60)
                    .HasDefaultValue("");

                a.Property(a => a.Country)
                    .HasMaxLength(90)
                    .HasColumnName("Country")
                    .HasDefaultValue("");

                a.Property(a => a.City)
                    .HasMaxLength(100)
                    .HasColumnName("City")
                    .HasDefaultValue("");
            });
        }
    }
}

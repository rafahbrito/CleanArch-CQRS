using CleanArch_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch_CQRS.Infra.EntityConfig;
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
        builder.Property(m => m.Email).HasMaxLength(150).IsRequired();
        builder.Property(m => m.IsActive).IsRequired();

        builder.HasData(
            new Member(1, "Jucá", "Pinhamangaba", "masculino", "johndoe@email.com", true),
            new Member(2, "Maria", "Bonita", "feminino", "mariabonita@email.com", true)
        );
    }
}

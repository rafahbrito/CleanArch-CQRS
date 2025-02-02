using CleanArch_CQRS.Domain.Entities;
using CleanArch_CQRS.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_CQRS.Infra.Context;
public class MemberDbContext : DbContext
{
    public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
    }
}

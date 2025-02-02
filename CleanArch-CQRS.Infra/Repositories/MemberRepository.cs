using CleanArch_CQRS.Domain.Abstractions;
using CleanArch_CQRS.Domain.Entities;
using CleanArch_CQRS.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch_CQRS.Infra.Repositories;
public class MemberRepository : IMemberRepository
{
    protected readonly MemberDbContext db;

    public MemberRepository(MemberDbContext _db)
    {
        db = _db;
    }

    public async Task<Member> AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(nameof(member));
        await db.Members.AddAsync(member);
        return member;
    }

    public async Task<Member> DeleteMember(int memberId)
    {
        var member = await GetMemberById(memberId) ?? throw new InvalidOperationException("Member not found");
        db.Members.Remove(member);
        return member;
    }

    public async Task<IEnumerable<Member>> GetAllMembers()
    {
        var membersList = await db.Members.ToListAsync();
        return membersList ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> GetMemberById(int memberId)
    {
        var member = await db.Members.FindAsync(memberId) ?? throw new InvalidOperationException("Member not found");
        return member;
    }

    public void UpdateMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(nameof(member));
        db.Members.Update(member);
    }
}

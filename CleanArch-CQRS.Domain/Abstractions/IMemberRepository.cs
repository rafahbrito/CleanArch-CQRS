using CleanArch_CQRS.Domain.Entities;

namespace CleanArch_CQRS.Domain.Abstractions;
public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAllMembers();
    Task<Member> GetMemberById(int memberId);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int memberId);
}

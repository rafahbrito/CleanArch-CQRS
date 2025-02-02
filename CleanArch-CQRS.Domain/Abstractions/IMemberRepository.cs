using CleanArch_CQRS.Domain.Entities;

namespace CleanArch_CQRS.Domain.Abstractions;
public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetAll();
    Task<Member> GetMemberById(int memberId);
    Task<Member> AddMember(Member member);
    Task<Member> UpdateMember(Member member);
    Task<Member> DeleteMember(int memberId);
}

namespace CleanArch_CQRS.Domain.Abstractions;
public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
}

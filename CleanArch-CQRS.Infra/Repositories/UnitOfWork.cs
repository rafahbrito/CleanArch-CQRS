using CleanArch_CQRS.Domain.Abstractions;
using CleanArch_CQRS.Infra.Context;

namespace CleanArch_CQRS.Infra.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepository;
    private readonly MemberDbContext _memberDbContext;

    public UnitOfWork(MemberDbContext memberDbContext)
    {
        _memberDbContext = memberDbContext;
    }

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository ??= new MemberRepository(_memberDbContext);
        }
    }

    public async Task CommitAsync()
    {
        await _memberDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _memberDbContext.Dispose();
    }
}

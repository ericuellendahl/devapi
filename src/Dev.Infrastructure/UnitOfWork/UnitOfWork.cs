using Dev.Domain.Abstraction;
using Dev.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dev.Infrastructure.UnitOfWork;

public class UnitOfWork (AppContext context) : IUnitOfWork
{
    private readonly AppContext _context = context;

    public async Task<string> CommitAsync(CancellationToken cancellationToken = default, bool checkForConcurrency = false)
    {
        try
        {
             await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException) when (checkForConcurrency)
        {
            return "A concurrency violation occurred. Please try again.";            
        }

        return string.Empty;
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    => new GenericRepository<TEntity>(_context);

}
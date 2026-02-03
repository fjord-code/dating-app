using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public interface IAppUsersRepository
{
    IQueryable<AppUser> GetAll(bool trackItems = false);
    Task<AppUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}

public class AppUsersRepository : IAppUsersRepository
{
    private readonly DataContext _context;

    public AppUsersRepository(
        DataContext context)
    {
        _context = context;
    }

    public IQueryable<AppUser> GetAll(bool trackItems = false)
    {
        IQueryable<AppUser> result = _context.Users;

        if (!trackItems)
        {
            result = result.AsNoTracking();
        }

        return result;
    }

    public async Task<AppUser?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FindAsync(id, cancellationToken);
    }
}

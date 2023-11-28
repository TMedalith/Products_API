using si730ebu20211F955.API.Inventory.Domain.Repositories;
using si730ebu20211F955.API.Shared.Persistence.Contexts;

namespace si730ebu20211F955.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
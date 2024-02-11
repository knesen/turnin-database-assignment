using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class OrderRowRepository(LocalDatabaseContext context) : BaseRepository<OrderRowEntity>(context)
{
    private readonly LocalDatabaseContext _context = context;
}



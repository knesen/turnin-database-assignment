using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class OrderRepository(LocalDatabaseContext context) : BaseRepository<OrderEntity>(context)
{
    private readonly LocalDatabaseContext _context = context;
}

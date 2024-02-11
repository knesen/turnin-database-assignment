using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class ProductRepository(LocalDatabaseContext context) : BaseRepository<ProductEntity>(context)
{
    private readonly LocalDatabaseContext _context = context;
}

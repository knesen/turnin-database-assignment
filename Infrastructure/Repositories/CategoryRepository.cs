using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class CategoryRepository(LocalDatabaseContext context) : BaseRepository<CategoryEntity>(context)
{
    private readonly LocalDatabaseContext _context = context; 
}

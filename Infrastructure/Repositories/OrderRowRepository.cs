using Infrastructure.Contexts;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using System.Diagnostics;
using Infrastructure.Repositories;

namespace Infrastructure.Repositories;

public class OrderRowRepository(LocalDatabaseContext context) : BaseRepository<OrderRowEntity>(context)
{
    private readonly LocalDatabaseContext _context = context;

    public IEnumerable<OrderRowEntity> GetOrderRowsByOrderId(int orderId)
    {
        try
        {
            var all = _context.OrderRows;
            var result = new List<OrderRowEntity>();

            foreach (var item in all)
            {
                if (item.OrderId == orderId)                    
                    result.Add(item);
            };

            if (result != null)
                return result;

        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
            return null!;
    }
}



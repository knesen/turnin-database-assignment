using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class OrderRowService(OrderRowRepository repository, ProductRepository productRepository, OrderRepository orderRepository)
{
    private readonly OrderRowRepository _orderRowRepository = repository;
    private readonly ProductRepository _productRepository = productRepository;
    private readonly OrderRepository _orderRepository = orderRepository;

    public OrderRowEntity CreateOrderRow (ProductEntity product, OrderDTO orderDTO)
    {
        try
        {

        
        var orderEntity = new OrderEntity { 
            OrderId = orderDTO.OrderId,
            Status = orderDTO.Status,
            OrderRows = orderDTO.OrderRows,
            CreatedAt = orderDTO.CreatedAt,
            Customer = orderDTO.Customer,
            CustomerId = orderDTO.CustomerId,

        };
       
        var orderRowEntity = new OrderRowEntity
        {
            Product = product,
            OrderRowProductId = product.ProductId,
            OrderRowPrice = product.Price,
            OrderId = orderEntity.OrderId,
            Order = orderEntity,
        };


        var result = _orderRowRepository.Create(orderRowEntity);

        if (result != null)
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }


}

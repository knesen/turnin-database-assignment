using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class OrderService(OrderRowRepository orderRowRepository, CustomerRepository customerRepository, OrderRepository orderRepository, ProductRepository productRepository)
{
    private readonly OrderRowRepository _orderRowRepository = orderRowRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly OrderRepository _orderRepository = orderRepository;
    private readonly ProductRepository _productRepository = productRepository;

    public bool CreateOrder (OrderDTO order)
    {
        try
        {
                        
            var customerEntity = _customerRepository.GetOne(x => x.Email == order.Customer.Email);
            customerEntity ??= _customerRepository.Create(new CustomerEntity { CustomerId = order.CustomerId });
                                 
            

            if (customerEntity != null)
            {
                order.CustomerId = customerEntity.CustomerId;
                order.Customer = customerEntity;
            }
           

            var orderEntity = new OrderEntity
            {
                OrderId = order.OrderId,
                Status = order.Status,
                OrderRows = order.OrderRows,
                CreatedAt = order.CreatedAt,
                CustomerId = order.Customer.CustomerId,
                Customer = order.Customer,
            };

            var result = _orderRepository.Create(orderEntity);
            if (result != null)
            {
                return true;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return false;
    }

    public IEnumerable<OrderDTO> GetAllOrders()
    {
        var orders = new List<OrderDTO>();

        try
        {
            var result = _orderRepository.GetAll();
            foreach (var item in result)
                orders.Add(new OrderDTO
                {
                    OrderId = item.OrderId,
                    Status = item.Status,
                    OrderRows = item.OrderRows,
                    CreatedAt = item.CreatedAt,
                    CustomerId = item.Customer.CustomerId,
                    Customer = item.Customer,

                });
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }

        return orders;
    }

    public OrderEntity GetOneOrder(int orderId)
    {
        var result = _orderRepository.GetOne(x => x.OrderId == orderId);

        if (result != null) return result;
        else return null!;
    }

    public OrderEntity UpdateOneOrder(OrderEntity orderEntity)
    {
        var result = _orderRepository.Update(orderEntity);

        if (result != null)
            return result;
        else
            return null!;
    }

    public bool DeleteOneOrder(int orderId)
    {
        var result = _orderRepository.Delete(x => x.OrderId == orderId);

        return result;
    }
}

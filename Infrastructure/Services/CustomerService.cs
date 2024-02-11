using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)

{
    private readonly AddressRepository _addressRepository = addressRepository;
    private readonly CustomerRepository _customerRepository = customerRepository;

    public bool CreateCustomer(CustomerDTO customer)
    {
        try
        {

            var addressEntity = _addressRepository.GetOne(x =>
            x.StreetAddress == customer.Address.StreetAddress &&
            x.ZipCode == customer.Address.ZipCode&&
            x.City == customer.Address.City);             

            addressEntity ??= _addressRepository.Create(customer.Address);


            var customerEntity = new CustomerEntity
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AddressId = addressEntity.AddressId,
            };

            var result = _customerRepository.Create(customerEntity);
            if (result != null)
            {
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return false;
    }

    public IEnumerable<CustomerDTO> GetAllCustomers()
    {
        var customers = new List<CustomerDTO>();

        try
        {
            var result = _customerRepository.GetAll();
            foreach (var item in result)
                customers.Add(new CustomerDTO 
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    AddressId = item.AddressId,
                    Address = _addressRepository.GetOne(x => x.AddressId == item.AddressId)
        });
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }

        return customers;
    }

    public CustomerEntity GetOneCustomer(string Email)
    {
        var result = _customerRepository.GetOne(x => x.Email == Email);
        result.Address = _addressRepository.GetOne(x => x.AddressId == result.AddressId);

        if (result != null) return result;
        else return null!;

    }

    public CustomerEntity UpdateOneCustomer(CustomerEntity customerEntity)
    {
        var result = _customerRepository.Update(customerEntity);

        if (result != null)
            return result;
        else
            return null!;
    }

    public bool DeleteOneCustomer(string Email)
    {
        var result = _customerRepository.Delete(x => x.Email == Email);

        return result;
    }
}

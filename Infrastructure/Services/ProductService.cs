using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ProductService(CategoryRepository categoryRepository, ProductRepository productRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ProductRepository _productRepository = productRepository;

    public bool CreateProduct(ProductDTO product)
    {
        try
        {
        if (!_productRepository.Exists(x => x.ProductId == product.ProductId))
        {
            var categoryEntity = _categoryRepository.GetOne(x => x.CategoryName == product.CategoryName);
            categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = product.CategoryName });

            var productEntity = new ProductEntity
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = categoryEntity.CategoryId,
            };
            
            var result = _productRepository.Create(productEntity);
            if (result != null)
                return true;                  

        }

        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return false;
    }

    public IEnumerable<ProductDTO> GetAllProducts()
    {
        var products = new List<ProductDTO>();

        try
        {
        var result = _productRepository.GetAll();

        foreach (var item in result)
            products.Add(new ProductDTO
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Description = item.Description,
                Price = item.Price,
                CategoryName = item.Category.CategoryName
            });
            
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        
        return products;        
    }

    public ProductEntity GetOneProduct(string productId)
    {
        var result = _productRepository.GetOne(x => x.ProductId == productId);

        if (result != null) return result;
        else return null!;
        
    }
    public ProductEntity UpdateOneProduct(ProductEntity productEntity)
    {
        var result = _productRepository.Update(productEntity);

        if (result != null)
            return result;
        else
            return null!;        
        
    }

    public bool DeleteOneProduct(string productId)
    {
        var result =  _productRepository.Delete(x => x.ProductId == productId);

        return result;
    }

}

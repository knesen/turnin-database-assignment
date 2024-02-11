using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Services;

public class MenuService(CustomerService customerService, OrderService orderService, ProductService productService, OrderRowService orderRowService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly OrderService _orderService = orderService;
    private readonly ProductService _productService = productService;
    private readonly OrderRowService _orderRowService = orderRowService;

    public void NavigationMenu()
    {
        Console.WriteLine("Välj en kategori i menyn");
        Console.WriteLine("1: Produkter");
        Console.WriteLine("2: Kunder");
        Console.WriteLine("3: Ordrar");
        Console.WriteLine("0: Stäng programmet");

        int option = Convert.ToInt32(Console.ReadLine());
        switch(option)
        {
            case 1: ProductMenu();
                break;

            case 2: CustomerMenu();
                break;

            case 3: OrderMenu();
                break;

            default:
                break;
        }
    }

    public void ProductMenu()
    {
        Console.WriteLine("Välj ett alternativ i menyn");
        Console.WriteLine("1: Skapa en ny produkt");
        Console.WriteLine("2: Visa alla produkter");
        Console.WriteLine("3: Visa en produkt");
        Console.WriteLine("4: Ta bort en produkt");
        Console.WriteLine("0: Gå tillbaka");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1: CreateNewProductMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            case 2: GetAllProductsMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            case 3: GetOneProductMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            case 4: DeleteProductMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            default: NavigationMenu();
                break;
        }
    }

    public void CustomerMenu()
    {
        Console.WriteLine("Välj ett alternativ i menyn");
        Console.WriteLine("1: Skapa en ny kund");
        Console.WriteLine("2: Visa alla kunder");
        Console.WriteLine("3: Visa en kund");
        Console.WriteLine("4: Ta bort en kund");
        Console.WriteLine("0: Gå tillbaka");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                CreateNewCustomerMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 2:
                GetAllCustomersMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 3:
                GetOneCustomerMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 4:
                DeleteCustomerMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            default: NavigationMenu();
                break;
        }
    }

    public void OrderMenu()
    {
        Console.WriteLine("Välj ett alternativ i menyn");
        Console.WriteLine("1: Skapa en ny order");
        Console.WriteLine("2: Visa alla ordrar");
        Console.WriteLine("3: Visa en order");
        Console.WriteLine("4: Ta bort en order");
        Console.WriteLine("0: Gå tillbaka");

        int option = Convert.ToInt32(Console.ReadLine());
        switch (option)
        {
            case 1:
                CreateNewOrderMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 2:
                GetAllOrdersMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 3:
                GetOneOrderMenu();
                Console.ReadKey();
                NavigationMenu();
                break;
            case 4:
                DeleteOrderMenu();
                Console.ReadKey();
                NavigationMenu();
                break;

            default: NavigationMenu();
                break;
        }
    }

    public void CreateNewProductMenu()
    {
        var formProduct = new ProductDTO();

        var formCategory = new CategoryEntity();

        Console.WriteLine("Skapa en ny produkt");

        Console.Write("Artikelnummer: ");
        formProduct.ProductId = Console.ReadLine()!;

        Console.Write("Produktnamn: ");
        formProduct.ProductName = Console.ReadLine()!;

        Console.Write("Produktbeskrivning: ");
        formProduct.Description = Console.ReadLine()!;

        Console.Write("Pris i SEK: ");
        formProduct.Price = Convert.ToInt32(Console.ReadLine());

        Console.Write("Produktkategori: ");
        formCategory.CategoryName = Console.ReadLine()!;

        formProduct.CategoryName = formCategory.CategoryName!;

        Console.Clear();

        var result = _productService.CreateProduct(formProduct);

        if (result)
            Console.WriteLine($"Produkten {formProduct.ProductName} i kategorin {formCategory.CategoryName} skapades");
        else
            Console.WriteLine($"Produkten kunde inte skapas");

    }
    public void GetAllProductsMenu()
    {
        Console.WriteLine("Visar alla produkter i databasen:");
        var result = _productService.GetAllProducts();

        Console.WriteLine(result);
    }

    public void GetOneProductMenu()
    {
        Console.WriteLine("Visa en produkt");
        Console.Write("Artikelnummer: ");

        string productId = Console.ReadLine()!;

        var result = _productService.GetOneProduct(productId);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine($"Artikelnummer: {result.ProductId}");
            Console.WriteLine($"Produktnamn: {result.ProductName}");
            Console.WriteLine($"Pris: {result.Price}");
            Console.WriteLine($"Kategori: {result.Category.CategoryName}");
            Console.WriteLine();           

        }
        else
            Console.WriteLine($"Ingen produkt med artikelnummer {productId} kunde hittas");
    }
   

    public void DeleteProductMenu()
    {
        Console.WriteLine("Ta bort en produkt");
        Console.Write("Artikelnummer: ");

        string productId = Console.ReadLine()!;

        var result = _productService.DeleteOneProduct(productId);

        Console.Clear();

        if (result)
            Console.WriteLine($"Produkten med artikelnummer {productId} togs bort");
        else
            Console.WriteLine("Produkten kunde inte tas bort");
    }

    public void CreateNewCustomerMenu()
    {
        var formCustomer = new CustomerDTO();

        var formAddress = new AddressEntity();

        formAddress.AddressId = Guid.NewGuid();
        formCustomer.CustomerId = Guid.NewGuid();
                       
        Console.WriteLine("Skapa en ny kund");

        Console.Write("Förnamn: ");
        formCustomer.FirstName = Console.ReadLine()!;

        Console.Write("Efternamn: ");
        formCustomer.LastName = Console.ReadLine()!;

        Console.Write("E-postadress: ");
        formCustomer.Email = Console.ReadLine()!;

        Console.Write("Telefonnummer: ");
        formCustomer.PhoneNumber = Console.ReadLine()!;

        Console.Write("Gatuadress: ");
        formAddress.StreetAddress = Console.ReadLine()!;

        Console.Write("Postnummer: ");
        formAddress.ZipCode = Console.ReadLine()!;

        Console.Write("Stad: ");
        formAddress.City = Console.ReadLine()!;


        formCustomer.AddressId = formAddress.AddressId;
        formCustomer.Address = formAddress;

        
        var result = _customerService.CreateCustomer(formCustomer);

        Console.Clear();

        if (result)
            Console.WriteLine($"Kunden {formCustomer.FirstName} {formCustomer.LastName} skapades.");
        else
            Console.WriteLine($"Kunden kunde inte skapas");

    }

    public void GetAllCustomersMenu()
    {
        Console.WriteLine("Visar alla kunder i databasen:");
        var result = _customerService.GetAllCustomers();

        Console.Clear();

        Console.WriteLine(result);
    }

    public void GetOneCustomerMenu()
    {
        Console.WriteLine("Visa en kund");
        Console.Write("E-postadress: ");

        string email = Console.ReadLine()!;

        var result = _customerService.GetOneCustomer(email);

        Console.Clear();

        if (result != null)
        {
            Console.WriteLine($"Kundnummer: {result.CustomerId}");
            Console.WriteLine($"Namn: {result.FirstName} {result.LastName}");
            Console.WriteLine($"E-postadress: {result.Email}");
            Console.WriteLine($"Telefonnummer: {result.PhoneNumber}");
            Console.WriteLine();
            Console.WriteLine($"Gatuadress: {result.Address.StreetAddress}");
            Console.WriteLine($"Postkod: {result.Address.ZipCode}");
            Console.WriteLine($"Stad: {result.Address.City}");

        }

        else
            Console.WriteLine($"Ingen kund med e-postadressen {email} kunde hittas");
    }

    public void DeleteCustomerMenu()
    {
        Console.WriteLine("Ta bort en kund");
        Console.Write("E-postadress: ");

        string email = Console.ReadLine()!;

        var result = _customerService.DeleteOneCustomer(email);

        Console.Clear();

        if (result)
            Console.WriteLine($"Kunden med e-postadressen {email} togs bort");
        else
            Console.WriteLine("Kunden kunde inte tas bort");

    }

    public void CreateNewOrderMenu()
    {
        var formOrder = new OrderDTO();
        var formProduct = new ProductEntity();
        var formCustomer = new CustomerEntity();

        Console.WriteLine("Skapa en ny order");
        Console.WriteLine();
        Console.WriteLine("Lägg till en produkt");

        Console.Write("Artikelnummer: ");
        formProduct.ProductId = Console.ReadLine()!;
        
        Console.Write("Antal: ");        
        int quantity = Convert.ToInt32(Console.ReadLine());

        Console.Write("Kundens e-postadress: ");
        formCustomer.Email = Console.ReadLine()!;
                
        formCustomer = _customerService.GetOneCustomer(formCustomer.Email);

        formOrder.CustomerId = formCustomer.CustomerId;
        formOrder.Customer = formCustomer;
        formOrder.Status = "Created";
        var todaysDate = DateTime.Now;

        formOrder.CreatedAt = DateOnly.FromDateTime(todaysDate);
                
        formProduct = _productService.GetOneProduct(formProduct.ProductId);

        var formOrderRow = _orderRowService.CreateOrderRow(formProduct, formOrder);
        formOrderRow.Quantity = quantity;

        formOrder.OrderRows.Add(formOrderRow);

        var result = _orderService.CreateOrder(formOrder);

        Console.Clear();

        if (result)
            Console.WriteLine($"Ordern skapades.");
        else
            Console.WriteLine($"Ordern kunde inte skapas");

    }

    public void GetAllOrdersMenu()
    {
        Console.WriteLine("Visar alla ordrar i databasen:");
        var result = _orderService.GetAllOrders();

        Console.Clear();

        Console.WriteLine(result);
    }

    public void GetOneOrderMenu()
    {
        Console.WriteLine("Visa en order");
        Console.Write("Ordernummer: ");

        int orderId = Convert.ToInt32(Console.ReadLine()!);

        var result = _orderService.GetOneOrder(orderId);

        Console.Clear();

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine($"Ordernummer: {result.OrderId}");
            Console.WriteLine($"Kundnummer: {result.CustomerId}");
            new List<OrderRowEntity>(result.OrderRows).ForEach(row =>
            Console.WriteLine($"Produktnamn: {row.Product.ProductName}"));

        }
        else
            Console.WriteLine($"Ingen order med ordernummer {orderId} kunde hittas");
    }

    public void DeleteOrderMenu()
    {
        Console.WriteLine("Ta bort en order");
        Console.Write("Ordernummer: ");

        int orderId = Convert.ToInt32(Console.ReadLine()!);

        var result = _orderService.DeleteOneOrder(orderId);

        Console.Clear();

        if (result)
            Console.WriteLine($"Ordern med ordernummer {orderId} togs bort");
        else
            Console.WriteLine("Ordern kunde inte tas bort");
    }
}
        


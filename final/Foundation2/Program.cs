using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
            Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");

            // Create customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create products
            Product product1 = new Product("Laptop", "001", 1000.00m, 1);
            Product product2 = new Product("Mouse", "002", 25.00m, 2);
            Product product3 = new Product("Keyboard", "003", 50.00m, 1);
            Product product4 = new Product("Monitor", "004", 200.00m, 2);

            // Create orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order details
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order1.CalculateTotalCost()}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: {order2.CalculateTotalCost()}\n");
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public string ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    class Customer
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool LivesInUSA()
        {
            return Address.IsUSA();
        }
    }

    class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsUSA()
        {
            return Country.ToLower() == "usa";
        }

        public override string ToString()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }

    class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalCost();
            }
            total += customer.LivesInUSA() ? 5 : 35;
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in products)
            {
                label += $"{product.Name} ({product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
        }
    }
}

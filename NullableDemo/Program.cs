using System;
#nullable enable
namespace NullableDemo
{
    class Customer
    {
        public string Name { get; set; }
        public Customer(string name) => Name = name;
    }

    class Item
    {
        public string Id { get; set; }
        public Customer? Customer { get; set; }
        public Item(string id) => Id = id;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var customer1 = new Customer("Pelle");
            _ = new Customer(null);    // Should give warning

            var item1 = new Item("1");
            // Should give warning and throw exception
            // Console.WriteLine(item1.Customer.Name);

            // Should handle null reference
            Console.WriteLine(item1.Customer?.Name ?? "No customer defined");
            item1.Customer = customer1;
            Console.WriteLine(item1.Customer?.Name ?? "No customer defined");
        }
    }
}

#nullable restore

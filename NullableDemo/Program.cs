using System;

#nullable enable // if not specified in csproj

var item1 = new Item("1");
item1.Customer = new Customer("Pelle");

var item2 = new Item("2");
item2.Customer = new Customer(null);    // Should give warning
Console.WriteLine($"Customer 2: {item2.Customer.Name}");

Console.WriteLine(item1.Customer?.Name ?? "No customer defined");
// Should handle null reference
Console.WriteLine(item2.Customer?.Name ?? "No customer defined");

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

#nullable restore


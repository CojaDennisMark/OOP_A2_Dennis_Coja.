using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        bool exit = true;
        Dictionary<string, decimal> menus = new Dictionary<string, decimal> { { "Coffee", 10.00m } };
        Dictionary<string, decimal> order = new Dictionary<string, decimal>();

        while (exit)
        {
            Console.WriteLine("Welcome to the Coffee Shop!\r\n" +
            "1. Add Menu Item\r\n" +
            "2. View Menu\r\n" +
            "3. Place Order\r\n" +
            "4. View Order\r\n" +
            "5. Calculate Total\r\n" +
            "6. Remove Menu Item\r\n" +
            "7. Exit\r\n" +
            "Select an option: ");

            string selected = Console.ReadLine();

            switch (selected)
            {
                case "1":
                    Console.WriteLine("Enter item name: ");
                    string newMenuItem = Console.ReadLine();
                    Console.WriteLine("Enter item price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && price >= 0)
                    {
                        if (!menus.ContainsKey(newMenuItem))
                        {
                            menus.Add(newMenuItem, price);
                            Console.WriteLine("Item added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Item already exists in the menu.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Price. Please enter a valid decimal number.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Menu: ");
                    int i = 0;
                    foreach (var item in menus)
                    {
                        i++;
                        Console.WriteLine($"{i}. {item.Key} - {item.Value}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Menu: ");
                    i = 0;
                    foreach (var item in menus)
                    {
                        i++;
                        Console.WriteLine($"{i}. {item.Key} - {item.Value}");
                    }
                    Console.WriteLine("Enter the item number to order: ");
                    if (int.TryParse(Console.ReadLine(), out int orderNo) && orderNo >= 1 && orderNo <= menus.Count)
                    {
                        string itemToAdd = menus.Keys.ElementAt(orderNo - 1);
                        if (order.ContainsKey(itemToAdd))
                        {
                            Console.WriteLine("Item already in the order. Updating quantity...");
                        }
                        order[itemToAdd] = menus[itemToAdd];
                        Console.WriteLine("Item added to order!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Order number.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Your Order:");
                    if (order.Count > 0)
                    {
                        foreach (var item in order)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No items in the order.");
                    }
                    break;

                case "5":
                    decimal totalAmount = order.Values.Sum();
                    Console.WriteLine($"Total Amount Payable: {totalAmount}");
                    break;

                case "6":
                    Console.WriteLine("Menu: ");
                    i = 0;
                    foreach (var item in menus)
                    {
                        i++;
                        Console.WriteLine($"{i}. {item.Key} - {item.Value}");
                    }
                    Console.WriteLine("Enter the item number to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeNo) && removeNo >= 1 && removeNo <= menus.Count)
                    {
                        string itemToRemove = menus.Keys.ElementAt(removeNo - 1);
                        if (menus.Remove(itemToRemove))
                        {
                            Console.WriteLine("Item removed successfully!");
                            order.Remove(itemToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Item not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Item number.");
                    }
                    break;

                case "7":
                    exit = false;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select a number between 1 and 7.");
                    break;
            }
        }
    }
}

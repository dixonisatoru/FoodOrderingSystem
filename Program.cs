using System;
using FoodOrderingSystem.UI;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Title = "🔥 Food Ordering System — Dashboard";
        }
        catch { }

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Dashboard dashboard = new Dashboard();
        dashboard.Run();
    }
}
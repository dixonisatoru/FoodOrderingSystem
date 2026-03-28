using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Payments;

namespace FoodOrderingSystem.UI
{
    /// <summary>
    /// Dashboard Class - UI Rendering Layer
    /// Purpose: Handles all console UI rendering and user interaction for the Food Ordering System.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • ENCAPSULATION: Private fields (_cart, _allItems, _categories) with controlled access
    ///   • POLYMORPHISM: Method overloading (AddItem with 1 or 2 parameters)
    ///   • ABSTRACTION: Uses IPayment interface for flexible payment processing
    ///   • INHERITANCE: Utilizes inherited FoodItem subclasses (Burger, Pizza, Sushi)
    /// </summary>
    public class Dashboard
    {
        // ENCAPSULATION: Private fields with restricted access
        private Cart _cart;
        private List<FoodItem> _allItems;
        private Dictionary<string, List<FoodItem>> _categories;
        private string _promoCode = "TRYNEW";

        /// <summary>
        /// Constructor - Initializes the dashboard with cart and menu items.
        /// ENCAPSULATION: Sets up private state
        /// </summary>
        public Dashboard()
        {
            _cart = new Cart();
            InitializeMenu();
        }

        /// <summary>
        /// Initializes all food items organized by category.
        /// ENCAPSULATION: Private method - hides implementation details
        /// </summary>
        private void InitializeMenu()
        {
            _allItems = new List<FoodItem>
            {
                // Burgers
                new Burger("Hamburger", 10.00, 4.5, 1350, "Classic Beef"),
                new Burger("Cheese Burger", 12.50, 4.3, 980, "Whole Wheat Bun"),
                new Burger("Double Patty", 15.00, 4.7, 750, "Double Beef Smash"),
                new Burger("Chicken Burger", 11.00, 4.2, 620, "Crispy Chicken"),

                // Pizzas
                new Pizza("Pepperoni Pizza", 25.00, 4.1, 1100, "Thin Crust"),
                new Pizza("Margherita", 20.00, 4.4, 890, "Classic Italian"),
                new Pizza("BBQ Chicken Pizza", 28.00, 4.6, 670, "Smoky BBQ"),
                new Pizza("Hawaiian Pizza", 22.00, 3.9, 540, "Ham & Pineapple"),

                // Sushi
                new Sushi("Sushi Roll", 15.00, 4.1, 800, "Salmon & Avocado"),
                new Sushi("Nigiri Set", 18.00, 4.5, 650, "Assorted Fish"),
                new Sushi("Dragon Roll", 22.00, 4.7, 420, "Eel & Cucumber"),
                new Sushi("Tempura Roll", 16.00, 4.0, 530, "Shrimp Tempura"),
            };

            _categories = new Dictionary<string, List<FoodItem>>
            {
                { "Burger", _allItems.Where(i => i is Burger).ToList() },
                { "Pizza", _allItems.Where(i => i is Pizza).ToList() },
                { "Sushi", _allItems.Where(i => i is Sushi).ToList() },
            };
        }

        /// <summary>
        /// Displays the main dashboard with simplified UI (no decorative boxes).
        /// ENCAPSULATION: Controls what information is displayed
        /// </summary>
        public void DisplayDashboard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  🔥 MunchPal FOOD ORDERING SYSTEM 🔥\n");

            // ──────────── Line SECTION ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ══════════════════════════════════════════════════════════════════════════════");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     🍔 Burger          🍕 Pizza           🍣 Sushi");
            Console.ResetColor();

            // ──────────── Line SECTION ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────");
            Console.ResetColor();

            var popular = _allItems.OrderByDescending(i => i.TotalSold).Take(3).ToList();
            foreach (var item in popular)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"  • {item.GetDescription()}");
            }

            // ──────────── DELIVERY INFO DISPLAY ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  ══════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  📍 DELIVERY ADDRESS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("  📌 Po. 6017, Cordova, Cebu");
            Console.WriteLine("  ⏱  20 min estimated delivery");
            Console.ResetColor();

            // ──────────── CART DISPLAY ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  ══════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  🛒 Cart (Order ID: #{new Random().Next(1000, 9999)})");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────");
            Console.ResetColor();

            if (_cart.IsEmpty)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  (Cart is empty — add items to get started!)");
                Console.ResetColor();
            }
            else
            {
                foreach (var cartItem in _cart.Items)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  • {cartItem.Item.GetDescription()}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"    Qty: {cartItem.Quantity}     Subtotal: ${cartItem.Subtotal:F2}");
                }
            }

            // ──────────── PROMO CODE ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  ──────────────────────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  Promotion Code: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{_promoCode}");
            Console.ResetColor();

            // ──────────── PRICING SUMMARY ────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"  Sub Total                                          ${_cart.GetSubtotal():F2}");
            Console.WriteLine($"  Delivery Charge                                    ${_cart.DeliveryFee:F2}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  TOTAL                                              ${_cart.GetTotal():F2}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ══════════════════════════════════════════════════════════════════════════════\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Main application loop - handles user interaction.
        /// ENCAPSULATION: Manages application state
        /// </summary>
        public void Run()
        {
            bool running = true;

            while (running)
            {
                DisplayDashboard();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  ╔══════════════════════════════════════════╗");
                Console.WriteLine("  ║         🎯 ACTIONS                      ║");
                Console.WriteLine("  ╠══════════════════════════════════════════╣");
                Console.WriteLine("  ║  [1]  Select Category & Add Item        ║");
                Console.WriteLine("  ║  [2]  View Cart                         ║");
                Console.WriteLine("  ║  [3]  Checkout                          ║");
                Console.WriteLine("  ║  [4]  Clear Cart                        ║");
                Console.WriteLine("  ║  [5]  Exit                              ║");
                Console.WriteLine("  ╚══════════════════════════════════════════╝");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n  ▸ Enter your choice: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice) || choice < 1 || choice > 5)
                {
                    ShowError("Invalid choice! Please enter a number between 1 and 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        SelectCategoryAndAdd();
                        break;
                    case 2:
                        ViewCart();
                        break;
                    case 3:
                        Checkout();
                        break;
                    case 4:
                        _cart.Clear();
                        ShowSuccess("Cart cleared successfully!");
                        break;
                    case 5:
                        running = false;
                        ShowExitMessage();
                        break;
                }
            }
        }

        /// <summary>
        /// Allows user to select a category and add items to cart.
        /// POLYMORPHISM: Uses method overloading (AddItem with 1 or 2 parameters)
        /// </summary>
        private void SelectCategoryAndAdd()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║        📂 SELECT A CATEGORY             ║");
            Console.WriteLine("  ╠══════════════════════════════════════════╣");
            Console.WriteLine("  ║  [1]  🍔 Burger                         ║");
            Console.WriteLine("  ║  [2]  🍕 Pizza                          ║");
            Console.WriteLine("  ║  [3]  🍣 Sushi                          ║");
            Console.WriteLine("  ║  [0]  ← Back                            ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  ▸ Choose category: ");
            Console.ResetColor();

            //if user pick number > 4 = invalid!
            if (!int.TryParse(Console.ReadLine(), out int catChoice) || catChoice < 0 || catChoice > 3)
            {
                ShowError("Invalid category! Please try again.");
                return;
            }

            //if user pick 0 it will return!
            if (catChoice == 0) return;

            string[] catKeys = { "Burger", "Pizza", "Sushi" };
            string selectedCat = catKeys[catChoice - 1];
            var items = _categories[selectedCat];

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n  ──────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"    🍽  {selectedCat} Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  ──────────────────────────────────────────────────────");
            Console.ResetColor();

            //1-5 COLOR YELLOW
            for (int i = 0; i < items.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"    [{i + 1}] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(items[i].GetDescription());
            }
            //0 IS DARK GREY
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"    [0] ← Back");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  ▸ Select item: ");
            Console.ResetColor();

            //if the user pick >5 it will print invalid!
            if (!int.TryParse(Console.ReadLine(), out int itemChoice) || itemChoice < 0 || itemChoice > items.Count)
            {
                ShowError("Invalid item selection!");
                return;
            }
            // IF MA PROCEED IT WILL GO TO ENTER QUANTITY
            if (itemChoice == 0) return;

            FoodItem selectedItem = items[itemChoice - 1];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  ▸ Enter quantity: ");
            Console.ResetColor();
            //VALIDATION: QTY MUST BE A POSITIVE INT
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                ShowError("Invalid quantity! Must be a positive number.");
                return;
            }
            //IF MA PROCEED MA ADD SIYA SA CART SA ADD ITEM
            try
            {
                _cart.AddItem(selectedItem, qty);
                ShowSuccess($"Added {qty}x {selectedItem.Name} to cart!");
            }
            catch (ArgumentException ex)
            {
                ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Displays detailed cart summary.
        /// ENCAPSULATION: Controls cart display logic
        /// </summary>
        private void ViewCart()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║                     🛒 CART SUMMARY                         ║");
            Console.WriteLine("  ╠══════════════════════════════════════════════════════════════╣");
            Console.ResetColor();

            if (_cart.IsEmpty)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("  ║  Your cart is empty.                                        ║");
            }
            else
            {
                foreach (var item in _cart.Items)
                {
                    // -30 space, -5space, 8 space, f2= 2 decimal places
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"  ║  {item.Item.Name,-30} x{item.Quantity,-5} ${item.Subtotal,8:F2}    ║");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  ║    {item.Item.Variant,-53}  ║");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  ╠══════════════════════════════════════════════════════════════╣");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  ║  Sub Total:                                  ${_cart.GetSubtotal(),8:F2}    ║");
                Console.WriteLine($"  ║  Delivery Charge:                            ${_cart.DeliveryFee,8:F2}    ║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  ║  TOTAL:                                      ${_cart.GetTotal(),8:F2}    ║");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n  Press any key to return...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Handles checkout process with payment method selection.
        /// ABSTRACTION & POLYMORPHISM: Uses IPayment interface for flexible payment handling
        /// ENCAPSULATION: Manages checkout workflow privately
        /// </summary>
        private void Checkout()
        {
            if (_cart.IsEmpty)
            {
                ShowError("Your cart is empty! Add items before checkout.");
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine("  ║        💳 SELECT PAYMENT METHOD         ║");
            Console.WriteLine("  ╠══════════════════════════════════════════╣");
            Console.WriteLine("  ║  [1]  💳 PayPal                         ║");
            Console.WriteLine("  ║  [2]  📱 GCash                          ║");
            Console.WriteLine("  ║  [0]  ← Back                            ║");
            Console.WriteLine("  ╚══════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  ▸ Choose payment: ");
            Console.ResetColor();

            if (!int.TryParse(Console.ReadLine(), out int payChoice) || payChoice < 0 || payChoice > 2)
            {
                ShowError("Invalid payment method!");
                return;
            }

            if (payChoice == 0) return;

            // POLYMORPHISM: Interface-based — IPayment reference, different implementations
            IPayment payment;
            switch (payChoice)
            {
                case 1: payment = new PayPalPayment(); break;
                case 2: payment = new GCashPayment(); break;
                default: return;
            }

            double total = _cart.GetTotal();
            //PROCEED INTO ORDER CONFIRMATION
            // Display final order summary
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n  ═════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("    📋 ORDER CONFIRMATION");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────");

            foreach (var item in _cart.Items)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"    {item.Item.Name,-25} x{item.Quantity,-4} ${item.Subtotal:F2}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"    Subtotal:          ${_cart.GetSubtotal():F2}");
            Console.WriteLine($"    Delivery Fee:      ${_cart.DeliveryFee:F2}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    TOTAL:             ${total:F2}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ──────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"    Payment via: {payment.PaymentName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ═════════════════════════════════════════════════════");
            Console.ResetColor();

            // Process payment via the selected method (Polymorphism in action)
            payment.ProcessPayment(total);

            _cart.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  ✅ Order placed successfully! Thank you for your order!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n  Press any key to return to dashboard...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Shows error message to user.
        /// ENCAPSULATION: Private helper method for error display
        /// </summary>
        private void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ⚠️  {message}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Shows success message to user.
        /// ENCAPSULATION: Private helper method for success display
        /// </summary>
        private void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✅ {message}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Displays exit message and farewell.
        /// ENCAPSULATION: Private cleanup method
        /// </summary>
        private void ShowExitMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
  ╔══════════════════════════════════════════════════════════════╗
  ║                                                              ║
  ║      🔥 Thank you for using Food Ordering System! 🔥         ║
  ║                                                              ║
  ║             Goodbye! Have a delicious day!                   ║
  ║                                                              ║
  ║                                                              ║
  ╚══════════════════════════════════════════════════════════════╝
");
            Console.ResetColor();
        }
    }
}
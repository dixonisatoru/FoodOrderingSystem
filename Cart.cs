using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingSystem.Models
{
    /// <summary>
    /// Cart Class - Shopping Cart Management
    /// Purpose: Manages cart operations and item storage for food orders.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • ENCAPSULATION: Private list with controlled access via methods and properties
    ///   • POLYMORPHISM: Method overloading for AddItem (1 or 2 parameters)
    /// </summary>
    public class Cart
    {
        // ENCAPSULATION: Private list, accessed through methods and readonly property
        private List<CartItem> _items = new List<CartItem>();

        /// <summary>
        /// Gets a read-only view of cart items.
        /// ENCAPSULATION: Prevents external modification of the list
        /// </summary>
        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        /// <summary>
        /// Checks if cart is empty.
        /// ENCAPSULATION: Provides safe access to cart state
        /// </summary>
        public bool IsEmpty => _items.Count == 0;

        /// <summary>
        /// Delivery fee for all orders (homemade-based system).
        /// ENCAPSULATION: Fixed value, read-only property
        /// </summary>
        public double DeliveryFee => 10.00;

        /// <summary>
        /// POLYMORPHISM: AddItem Overload #1
        /// Adds item to cart with default quantity of 1.
        /// </summary>
        public void AddItem(FoodItem item)
        {
            AddItem(item, 1);
        }

        /// <summary>
        /// POLYMORPHISM: AddItem Overload #2
        /// Adds item to cart with specified quantity.
        /// If item already exists, increases its quantity.
        /// 
        /// OOP: ENCAPSULATION - Validates quantity before adding
        /// </summary>
        public void AddItem(FoodItem item, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");

            var existing = _items.FirstOrDefault(c => c.Item.Name == item.Name);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem(item, quantity));
            }
        }

        /// <summary>
        /// Calculates subtotal of all items in cart.
        /// ENCAPSULATION: Hides calculation logic
        /// </summary>
        public double GetSubtotal() => _items.Sum(i => i.Subtotal);

        /// <summary>
        /// Calculates total including delivery fee.
        /// ENCAPSULATION: Combines subtotal with delivery charge
        /// </summary>
        public double GetTotal() => GetSubtotal() + DeliveryFee;

        /// <summary>
        /// Clears all items from cart.
        /// ENCAPSULATION: Safe clearing method
        /// </summary>
        public void Clear() => _items.Clear();
    } // END OF Cart CLASS
} // END OF NAMESPACE
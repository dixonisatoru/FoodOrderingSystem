using System;

namespace FoodOrderingSystem.Models
{
    /// <summary>
    /// CartItem Class - Individual Cart Item
    /// Purpose: Represents a single item in the shopping cart with quantity.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • ENCAPSULATION: Private quantity field with validation
    /// </summary>
    public class CartItem
    {
        // ENCAPSULATION: Public read-only property for the food item
        public FoodItem Item { get; private set; }

        // ENCAPSULATION: Private quantity field with validation
        private int _quantity;

        /// <summary>
        /// Gets or sets the quantity of this cart item.
        /// ENCAPSULATION: Validates that quantity is greater than 0
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value > 0)
                    _quantity = value;
                else
                    throw new ArgumentException("Quantity must be greater than 0.");
            }
        }

        /// <summary>
        /// Calculates subtotal (item price × quantity).
        /// ENCAPSULATION: Read-only calculated property
        /// </summary>
        public double Subtotal => Item.Price * Quantity;

        /// <summary>
        /// Constructor for CartItem.
        /// ENCAPSULATION: Initializes item and quantity with validation
        /// </summary>
        public CartItem(FoodItem item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    } // END OF CartItem CLASS
} // END OF NAMESPACE
using System;

namespace FoodOrderingSystem.Models
{
    /// <summary>
    /// FoodItem Abstract Class - Base for all food types
    /// Purpose: Defines common properties and behavior for all food items.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • ABSTRACTION: Abstract base class with abstract method GetDescription()
    ///   • ENCAPSULATION: Private fields with validation via properties
    ///   • INHERITANCE: Base class for Burger, Pizza, and Sushi
    ///   • POLYMORPHISM: Subclasses override GetDescription() and ToCard()
    /// </summary>
    public abstract class FoodItem
    {
        // ========================================================
        // ENCAPSULATION: Private fields with controlled access
        // ========================================================
        private string _name;
        private double _price;
        private double _rating;
        private int _totalSold;
        private string _variant;

        /// <summary>
        /// Gets or sets the food item name.
        /// ENCAPSULATION: Validates that name is not empty
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = !string.IsNullOrWhiteSpace(value) ? value : "Unknown Item";
        }

        /// <summary>
        /// Gets or sets the food item price.
        /// ENCAPSULATION: Validates that price is greater than 0
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                if (value > 0)
                    _price = value;
                else
                    throw new ArgumentException("Price must be greater than 0.");
            }
        }

        /// <summary>
        /// Gets or sets the food item rating (0-5 scale).
        /// ENCAPSULATION: Validates rating range
        /// </summary>
        public double Rating
        {
            get => _rating;
            set => _rating = (value >= 0 && value <= 5) ? value : 0;
        }

        /// <summary>
        /// Gets or sets total units sold.
        /// ENCAPSULATION: Validates non-negative value
        /// </summary>
        public int TotalSold
        {
            get => _totalSold;
            set => _totalSold = value >= 0 ? value : 0;
        }

        /// <summary>
        /// Gets or sets variant/description of the item.
        /// ENCAPSULATION: Protects from null values
        /// </summary>
        public string Variant
        {
            get => _variant;
            set => _variant = value ?? "";
        }

        /// <summary>
        /// Constructor for FoodItem.
        /// ENCAPSULATION: Protected constructor - only accessible to derived classes
        /// </summary>
        protected FoodItem(string name, double price, double rating, int totalSold, string variant)
        {
            Name = name;
            Price = price;
            Rating = rating;
            TotalSold = totalSold;
            Variant = variant;
        }

        /// <summary>
        /// ABSTRACTION: Abstract method that subclasses must implement.
        /// Each food type provides its own unique description format.
        /// POLYMORPHISM: Overridden by Burger, Pizza, and Sushi classes
        /// </summary>
        public abstract string GetDescription();

        /// <summary>
        /// POLYMORPHISM: Virtual method that can be overridden by subclasses.
        /// Displays food item as a formatted card (simplified version).
        /// ENCAPSULATION: Formats display data internally
        /// </summary>
        public virtual string ToCard()
        {
            string stars = new string('★', (int)Rating) + new string('☆', 5 - (int)Rating);
            return $"  {Name} | ${Price:F2} | Rating: {stars} ({Rating:F1}) | Sold: {TotalSold}";
        }
    } // END OF FoodItem CLASS
} // END OF NAMESPACE
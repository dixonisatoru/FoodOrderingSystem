namespace FoodOrderingSystem.Models
{
    /// <summary>
    /// Pizza Class - Pizza Food Item
    /// Purpose: Represents a pizza in the food ordering system.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • INHERITANCE: Inherits from FoodItem abstract base class
    ///   • POLYMORPHISM: Overrides GetDescription() method
    /// </summary>
    public class Pizza : FoodItem
    {
        /// <summary>
        /// Constructor for Pizza.
        /// INHERITANCE: Calls base class constructor via base()
        /// </summary>
        public Pizza(string name, double price, double rating, int totalSold, string variant)
            : base(name, price, rating, totalSold, variant) { }

        /// <summary>
        /// POLYMORPHISM: Override - unique description for Pizza
        /// Each food type has its own specific emoji and format.
        /// INHERITANCE: Implements abstract method from FoodItem
        /// </summary>
        public override string GetDescription()
        {
            return $"🍕 {Name} - {Variant} | ${Price:F2} | Rating: {Rating:F1}★";
        }
    } // END OF Pizza CLASS
} // END OF NAMESPACE
namespace FoodOrderingSystem.Models
{
    /// <summary>
    /// Sushi Class - Sushi Food Item
    /// Purpose: Represents sushi in the food ordering system.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • INHERITANCE: Inherits from FoodItem abstract base class
    ///   • POLYMORPHISM: Overrides GetDescription() method
    /// </summary>
    public class Sushi : FoodItem
    {
        /// <summary>
        /// Constructor for Sushi.
        /// INHERITANCE: Calls base class constructor via base()
        /// </summary>
        public Sushi(string name, double price, double rating, int totalSold, string variant)
            : base(name, price, rating, totalSold, variant) { }

        /// <summary>
        /// POLYMORPHISM: Override - unique description for Sushi
        /// Each food type has its own specific emoji and format.
        /// INHERITANCE: Implements abstract method from FoodItem
        /// </summary>
        public override string GetDescription()
        {
            return $"🍣 {Name} - {Variant} | ${Price:F2} | Rating: {Rating:F1}★";
        }
    } // END OF Sushi CLASS
} // END OF NAMESPACE
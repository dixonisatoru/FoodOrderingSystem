namespace FoodOrderingSystem.Models
{
    /// Burger Class - Burger Food Item
    /// Purpose: Represents a burger in the food ordering system.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • INHERITANCE: Inherits from FoodItem abstract base class
    ///   • POLYMORPHISM: Overrides GetDescription() method

    public class Burger : FoodItem
    {

        /// Constructor for Burger.
        /// INHERITANCE: Calls base class constructor via base()

        public Burger(string name, double price, double rating, int totalSold, string variant)
            : base(name, price, rating, totalSold, variant) { }


        /// POLYMORPHISM: Override - unique description for Burger
        /// Each food type has its own specific emoji and format.
        /// INHERITANCE: Implements abstract method from FoodItem

        public override string GetDescription()
        {
            return $"🍔 {Name} - {Variant} | ${Price:F2} | Rating: {Rating:F1}★";
        }
    } // END OF Burger CLASS
} // END OF NAMESPACE
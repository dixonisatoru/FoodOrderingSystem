namespace FoodOrderingSystem.Payments
{
    /// <summary>
    /// IPayment Interface - Payment Contract
    /// Purpose: Defines a contract for all payment methods.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • ABSTRACTION: Defines abstract contract for payment processing
    ///   • POLYMORPHISM: Each payment class implements this interface differently
    /// </summary>
    public interface IPayment
    {
        /// <summary>
        /// Gets the name of the payment method.
        /// ABSTRACTION: Contract property that all payment types must have
        /// </summary>
        string PaymentName { get; }

        /// <summary>
        /// Processes payment for the given amount.
        /// ABSTRACTION: Contract method that all payment types must implement
        /// POLYMORPHISM: Different implementation for each payment type
        /// </summary>
        bool ProcessPayment(double amount);
    } // END OF IPayment INTERFACE
} // END OF NAMESPACE
using System;

namespace FoodOrderingSystem.Payments
{
    /// <summary>
    /// PayPalPayment Class - PayPal Payment Implementation
    /// Purpose: Implements PayPal payment processing.
    /// 
    /// OOP PRINCIPLES USED:
    ///   • POLYMORPHISM: Implements IPayment interface
    ///   • ENCAPSULATION: Private implementation details
    /// </summary>
    public class PayPalPayment : IPayment
    {
        /// <summary>
        /// Gets the payment method name.
        /// POLYMORPHISM: Implements IPayment.PaymentName property
        /// </summary>
        public string PaymentName => "PayPal";

        /// <summary>
        /// Processes PayPal payment.
        /// POLYMORPHISM: Implements IPayment.ProcessPayment method
        /// ENCAPSULATION: Hides PayPal-specific implementation
        /// </summary>
        public bool ProcessPayment(double amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine($"  ║       💳 PayPal Payment Processing       ║");
            Console.WriteLine($"  ╠══════════════════════════════════════════╣");
            Console.WriteLine($"  ║  Amount Charged: ${amount:F2}                ║");
            Console.WriteLine($"  ║  Status: ✅ Payment Successful!          ║");
            Console.WriteLine($"  ║  Transaction ID: PP-{new Random().Next(100000, 999999)}          ║");
            Console.WriteLine($"  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            return true;
        }
    } // END OF PayPalPayment CLASS
} // END OF NAMESPACE
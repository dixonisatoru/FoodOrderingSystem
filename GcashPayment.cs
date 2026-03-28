using System;

namespace FoodOrderingSystem.Payments
{
    /// <summary>
    /// CLASS: GCashPayment
    /// PURPOSE: Implements GCash as a payment method
    /// 
    /// OOP PRINCIPLES USED:
    /// - POLYMORPHISM (Interface Implementation): Implements IPayment interface
    ///   Provides specific behavior for ProcessPayment() method
    /// - ABSTRACTION: Hidden implementation details - caller doesn't need to know
    ///   how GCash processes payments
    /// </summary>
    public class GCashPayment : IPayment
    {
        /// <summary>
        /// POLYMORPHISM: GCash-specific payment method name
        /// </summary>
        public string PaymentName => "GCash";

        /// <summary>
        /// POLYMORPHISM (Override): GCash-specific implementation of ProcessPayment
        /// Shows GCash-themed UI with Green color
        /// Generates a GCash reference number
        /// </summary>
        public bool ProcessPayment(double amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ╔══════════════════════════════════════════╗");
            Console.WriteLine($"  ║       📱 GCash Payment Processing        ║");
            Console.WriteLine($"  ╠══════════════════════════════════════════╣");
            Console.WriteLine($"  ║  Amount Charged: ${amount:F2}                ║");
            Console.WriteLine($"  ║  Status: ✅ Payment Successful!          ║");
            Console.WriteLine($"  ║  Ref No: GC-{new Random().Next(100000, 999999)}               ║");
            Console.WriteLine($"  ╚══════════════════════════════════════════╝");
            Console.ResetColor();
            return true;
        }
    }
}
using icetask2.Models;

namespace icetask2.Views.Orders
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public Task<string> ProcessPayment(Order order)
        {
            // Simulate processing payment
            return Task.FromResult("Credit Card Payment Processed");
        }
    }

}

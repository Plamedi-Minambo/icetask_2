using icetask2.Models;

namespace icetask2.Views.Orders
{
    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public async Task<string> ProcessOrderPayment(Order order)
        {
            return await _paymentProcessor.ProcessPayment(order);
        }
    }
}

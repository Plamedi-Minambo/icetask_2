using icetask2.Models;

namespace icetask2.Views.Orders
{
    public interface IPaymentProcessor
    {
        Task<string> ProcessPayment(Order order);
    }
}

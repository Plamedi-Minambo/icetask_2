using icetask2.Models;

namespace icetask2.Views.Orders
{
    public interface IOrderPayment
    {
        Task<string> ProcessPayment(Order order);
    }

}

using icetask2.Models;

namespace icetask2.Views.Orders
{
    public interface IOrderPlacement
    {
        Task<string> PlaceOrder(Order order);
    }

}

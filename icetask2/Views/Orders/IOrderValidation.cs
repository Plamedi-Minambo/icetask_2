using icetask2.Models;

namespace icetask2.Views.Orders
{
    public interface IOrderValidation
    {
        bool ValidateOrder(Order order);
    }

}

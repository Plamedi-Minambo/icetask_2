using icetask2.Models;

namespace icetask2.Views.Orders
{
    public class OrderValidation : IOrderValidation
    {
        public bool ValidateOrder(Order order)
        {
            // Add basic validation logic
            return order.Quantity > 0 && !string.IsNullOrEmpty(order.Product);
        }
    }

}

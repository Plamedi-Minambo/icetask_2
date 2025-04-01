using icetask2.Data;
using icetask2.Models;
using icetask2.Views.Orders;


public class OrderService : IOrderService
{
    private readonly icetask2Context _context;
    private readonly IOrderValidation _orderValidator;

    public OrderService(icetask2Context context, IOrderValidation orderValidator)
    {
        _context = context;
        _orderValidator = orderValidator;
    }

    public Task DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetOrderByIdAsync(int value)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public bool OrderExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> OrderExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<string> ProcessOrder(Order order)
    {
        throw new NotImplementedException();
    }

    public async Task<string> ProcessOrderAsync(Order order)
    {
        if (!_orderValidator.ValidateOrder(order))
        {
            return "Invalid order. Please check product name and quantity.";
        }

        // Normally, you'd save to a database, but since you don't need a DB, return a mock message
        return await Task.FromResult("Order processed successfully!");
    }

    public Task UpdateOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    Task IOrderService.ProcessOrderAsync(Order order)
    {
        return ProcessOrderAsync(order);
    }
}

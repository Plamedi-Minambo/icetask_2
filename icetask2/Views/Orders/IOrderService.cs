using icetask2.Models;
using System.Threading.Tasks;
namespace icetask2.Views.Orders
{
    public interface IOrderService
    {
        Task DeleteOrderAsync(int id);
        Task<string?> GetOrderByIdAsync(int value);
        Task<string?> GetOrdersAsync();
        bool OrderExists(int id);
        Task<string> ProcessOrder(Order order);
      
        Task UpdateOrderAsync(Order order);
        Task<bool> OrderExistsAsync(int id);
        Task<string> ProcessOrderAsync(Order order);
    }
}

using icetask2.Models;
 // Ensure you are using the correct namespace for IOrderService
using icetask2.Views.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // GET: Orders
    public async Task<IActionResult> Index()
    {
        var orders = await _orderService.GetOrdersAsync(); // Retrieve orders using the service
        return View(orders);
    }

    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var order = await _orderService.GetOrderByIdAsync(id.Value);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Orders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OrderId,Product,Quantity,TotalAmount")] Order order)
    {
        if (ModelState.IsValid)
        {
            var result = await _orderService.ProcessOrderAsync(order);
            if (result.Contains("Order processed"))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", result); // Show error message if validation fails
        }
        return View(order);
    }

    // GET: Orders/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var order = await _orderService.GetOrderByIdAsync(id.Value);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }

    // POST: Orders/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("OrderId,Product,Quantity,TotalAmount")] Order order)
    {
        if (id != order.OrderId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var exists = await _orderService.OrderExistsAsync(order.OrderId);
            if (!exists)
            {
                return NotFound();
            }

            await _orderService.UpdateOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }
        return View(order);
    }

    // GET: Orders/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue)
        {
            return NotFound();
        }

        var order = await _orderService.GetOrderByIdAsync(id.Value);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> OrderExists(int id)
    {
        return await _orderService.OrderExistsAsync(id);
    }
}

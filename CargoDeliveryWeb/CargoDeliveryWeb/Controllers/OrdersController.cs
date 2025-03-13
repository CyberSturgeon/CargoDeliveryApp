using CargoDeliveryWeb.Data;
using CargoDeliveryWeb.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoDeliveryWeb.Controllers;


public class OrdersController(AppDbContext _context, IValidator<Order> validator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await _context.Orders
            .OrderByDescending(o => o.PickupDate)
            .ToListAsync();

        return View(orders);
    }

    public IActionResult Create()
    {
        return View(new Order());
    }

    [HttpPost()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Order order)
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }
        else
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = order.Id });
        }
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(m => m.Id == id);

        return order != null ? View(order) : NotFound();
    }
}

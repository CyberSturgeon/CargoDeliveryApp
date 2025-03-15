using AutoMapper;
using CargoDeliveryWeb.Business.Models;
using CargoDeliveryWeb.Business.Services.Interfaces;
using CargoDeliveryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CargoDeliveryWeb.Controllers;


public class OrdersController(IOrderService orderService, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> Index()
    {
        var orders = mapper.Map<List<OrderResponse>>(await orderService.GetAllAsync())
            .OrderByDescending(x => x.Id);

        return View(orders);
    }

    public IActionResult Create()
    {
        return View(new OrderResponse());
    }

    [HttpPost()]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderRequest order)
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }
        else
        {
            await orderService.AddAsync(mapper.Map<OrderModel>(order));
            return RedirectToAction(nameof(Index));
        }
    }

    public async Task<ActionResult<OrderResponse>> Details(Guid id)
    {
        var order = mapper.Map<OrderResponse>(await orderService.GetByIdAsync(id));

        return order != null ? View(order) : NotFound();
    }
}

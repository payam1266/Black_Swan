using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Black_Swan.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderController(IOrderService orderService, IProductService productService, IOrderDetailsService orderDetailsService)
        {
            _orderService = orderService;
            _productService = productService;
            _orderDetailsService = orderDetailsService;
        }
        // GET: OrderController
        public async Task<IActionResult> ListOfOrders()
        {
            var orders =await _orderService.GetOrders();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create(int productId, int quantity)
        {
            ViewData["productId"] = productId;
            ViewData["quantity"] = quantity;
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderVM orderVM, int productId, int quantity)
        {
            try
            {
                var product = await _productService.GetProductWithDetails(productId);

                orderVM.Status = OrderVM.OrderStatus.Paid;
                orderVM.TotalPrice = product.price * quantity;
                if (product.count >= quantity)
                {
                    var response = await _orderService.CreateOrder(orderVM);
                    if (response.Success)
                    {
                        var orderDetails = new OrderDetailsVM
                        {

                            ProductId = productId,
                            ProductName = product.name,
                            ProductPrice = product.price,
                            Quantity = quantity,
                            Subtotal = quantity * product.price,
                            OrderId = response.Data
                        };

                        await _orderDetailsService.CreateOrderDetails(orderDetails);

                    }
                    ModelState.AddModelError("", response.ValidationErrors);
                    
                       
                }
                else
                {
                    return Json($"The Inventory Of {product.name} Is Not Enough");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("index", "Product");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            try
            {
                var response = await _orderService.DeleteOrder(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(ListOfOrders));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }

      
    }
}

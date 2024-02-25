using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Black_Swan.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var products = await _productService.GetProductList();

            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            var product = await _productService.GetProductWithDetails(id);
            return View(product);
           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(CreateProductVM createProductVM)
        {

            try
            {
                var responsse = await _productService.CreateProduct(createProductVM);
                if (responsse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", responsse.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(createProductVM);
        }

        // GET: ProductController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var product = await _productService.GetProductWithDetails(id);

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit(int id, ProductVM productVM)
        {
            try
            {
                var response = await _productService.UpdateProduct(id, productVM);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(productVM);
        }

        // GET: ProductController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            try
            {
                var responsse = await _productService.DeleteProduct(id);
                if (responsse.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", responsse.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }

        
    }
}

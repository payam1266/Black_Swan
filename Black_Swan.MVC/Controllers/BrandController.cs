using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Black_Swan.MVC.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        // GET: BrandController
        public async Task<ActionResult> Index()
        {
            var Brands = await _brandService.GetBrandsList();
            return View(Brands);
        }
        // GET: BrandController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: BrandController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBrandVM createBrandVM)
        {
            try
            {
                var response = await _brandService.CreateBrand(createBrandVM);
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
            return View(createBrandVM);
        }
        // GET: BrandController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var brand = await _brandService.GetBrand(id);
            return View(brand);
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BrandVM brandVM)
        {
            try
            {
                var response = await _brandService.UpdateBrand(id,brandVM);
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
            return View(brandVM);
        }
        // GET: BrandController/Details/5
        public async Task< ActionResult> Details(int id)
        {
            var Brand = await _brandService.GetBrand(id);
            return View(Brand);
           
        }

        // GET: BrandController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            try
            {
                var response = await _brandService.DeleteBrand(id);
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
            return BadRequest();

        }

    }
}

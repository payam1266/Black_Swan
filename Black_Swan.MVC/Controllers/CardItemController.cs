using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Black_Swan.MVC.Controllers
{
    [Authorize]
    public class CardItemController : Controller
    {
        private readonly ICardItemService _cardItemService;
        private readonly IProductService _productService;
        private readonly IAuthenticateService _authenticateService;

        public CardItemController(ICardItemService cardItemService, IProductService productService, IAuthenticateService authenticateService)
        {
            _cardItemService = cardItemService;
            _productService = productService;
            _authenticateService = authenticateService;
        }
        // GET: CardItemController
        public async Task<ActionResult> Index()
        {
            var CardItems = await _cardItemService.GetCardItemsList();
            return View(CardItems);
        }
        public async Task<IActionResult> Create(int productId,string userid,int quantity)
        {
           

            var product = await _productService.GetProductWithDetails(productId);
            //var userId = _authenticateService.GetCurrentUserName();
         
          

            var cardItemVM = new CardItemVM
            {
                Productid = product.id,
                Userid = userid,
                Productprice = product.price,
                Productcount = quantity,
                Productname=product.name,
            };
            try
            { 
            var response = await _cardItemService.CreateCardItem(cardItemVM);
            if (response.Success)
            {
                return RedirectToAction(nameof(Index)); 
            }
          
                ModelState.AddModelError("", response.ValidationErrors);

            }

            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
           
                return RedirectToAction("Details", "Product");
            
        }
        // GET: CardItemController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var card = await _cardItemService.GetCardItem(id);
            return View(card);
        }
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var responsse = await _cardItemService.DeleteCardItem(id);
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

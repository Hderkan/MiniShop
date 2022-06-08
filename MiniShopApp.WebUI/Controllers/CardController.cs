using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniShopApp.Business.Abstract;
using MiniShopApp.WebUI.Identity;
using MiniShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private ICardService _cardService;
        private UserManager<User> _userManager;

        public CardController(ICardService cardService, UserManager<User> userManager)
        {
            _cardService = cardService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var card = _cardService.GetCardByUserId(_userManager.GetUserId(User));
            var model = new CardModel()
            {
                CardId = card.Id,
                CardItems = card.CardItems.Select(i => new CardItemModel()
                {
                    CardItemId=i.Id,
                    ProductId=i.ProductId,
                    Name=i.Product.Name,
                    Price=(double)i.Product.Price,
                    ImageUrl=i.Product.ImageUrl,
                    Quantity=i.Quantity
                }).ToList()
            };
            return View(model);
        }
    }
}

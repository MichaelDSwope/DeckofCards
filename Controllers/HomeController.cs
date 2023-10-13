using DeckofCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckofCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeckOfCardsService _deckOfCardsService;

        public HomeController(ILogger<HomeController> logger, IDeckOfCardsService deckOfCardsService)
        {
            _logger = logger;
            _deckOfCardsService = deckOfCardsService;
        }
        public async Task<IActionResult> Index()
        {
            string  deckId =await _deckOfCardsService.CreateNewDeckAsync();
            var cards = await _deckOfCardsService.GetCardsAsync(deckId);

            return View(cards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
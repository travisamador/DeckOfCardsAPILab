using DeckOfCardsLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace DeckOfCardsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public DeckDAL deckDAL = new DeckDAL();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DeckDisplay(string card)
        {
            DeckModel model = new DeckModel();
            if(model.remaining < 5)
            {
                ShuffleCards();
            }
            DeckModel result = deckDAL.GetCards(card);
            return View(result);
        }
        public IActionResult DeckDraw()
        {  

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void ShuffleCards()
        {
            string key = "9x0u2du1k22h";
            string url = $"https://deckofcardsapi.com/api/deck/{key}/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}
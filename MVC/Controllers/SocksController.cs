using Microsoft.AspNetCore.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
    [Route("socks")]
    [Route("ponozky")]
    public class SocksController : Controller
    {
        public IActionResult Index()
        {
            var data = SocksDataset.GetSocks();

            return View(data);
        }
        [Route("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            var data = SocksDataset.GetSocks()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(data);
        }

        [Route("[action]")]
        [Route("[action]/min/{priceMin:int}/max/{priceMax:int}")]
        public IActionResult SearchByPrice(int priceMin, int priceMax)
        {
            var data = SocksDataset.GetSocks()
                .Where(x => x.Price >= priceMin && x.Price <= priceMax);

            return View("Index", data);
        }
    }
}

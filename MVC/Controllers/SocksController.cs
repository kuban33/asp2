using Microsoft.AspNetCore.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
    public class SocksController : Controller
    {
        public IActionResult Index()
        {
            var data = SocksDataset.GetSocks();

            return View(data);
        }
        public IActionResult GetById(int id)
        {
            var data = SocksDataset.GetSocks()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return View(data);
        }
    }
}

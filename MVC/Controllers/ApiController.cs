using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class ApiController : ControllerBase
    {
        public Socks GetById(int id)
        {
            var data = SocksDataset.GetSocks()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return data;

        }
    }
}

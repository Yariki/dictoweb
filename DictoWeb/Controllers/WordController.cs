using Microsoft.AspNetCore.Mvc;

namespace DictoWeb.Controllers
{
    public class WordController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace YouDeliverAPI.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

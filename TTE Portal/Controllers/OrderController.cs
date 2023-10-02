using Microsoft.AspNetCore.Mvc;

namespace TTE_Portal.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders() { 
        
        return View();
        
        }

        public IActionResult OrderDetails()
        {
            return View();
        }
    }
}

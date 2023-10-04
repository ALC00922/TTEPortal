using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TTE_Portal.Data;
using TTE_Portal.ViewModels;

namespace TTE_Portal.Controllers
{
    public class OrderController : Controller
    {
        private TTE_PortalContext _context;
        string _userId = string.Empty;
        public OrderController(TTE_PortalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Orders()
        {
            List<OrdersViewModel> orders = new List<OrdersViewModel>();
            // Inside a controller action or service method
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                _userId = userIdClaim.Value;
                // Now you have the user's ID in the 'userId' variable.
            }
            else
            {
                // User is not authenticated, or the claim doesn't exist.
            }
            var awbEntries = _context.AwbEntries.Where(x => x.CreatedBy == _userId).ToList();
            var piEntries = _context.PIEntries.Where(x => x.CreatedBy == _userId).ToList();

            for (int i = 0; i < awbEntries.Count; i++)
            {
                OrdersViewModel order = new OrdersViewModel();
                order.PINO = awbEntries[i].PINo;
                order.PIDate = piEntries[i].CreatedDate.ToShortDateString();
                order.Model = piEntries[i].ItemDesc;
                order.QTY =Convert.ToDouble(piEntries[i].ItemQty);
                orders.Add(order);
            }

            return View(orders);

        }

        public IActionResult OrderDetails()
        {
            return View();
        }
    }
}

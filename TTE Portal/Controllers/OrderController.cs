using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TTE_Portal.Data;
using TTE_Portal.ViewModels;
using static NuGet.Packaging.PackagingConstants;

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
            var awbEntries = _context.AwbEntries.Where(x => x.CreatedBy == "ef351a27-3983-408e-abda-4c61c9a3840a").ToList();
            var piEntries = _context.PIEntries.Where(x => x.CreatedBy == "ef351a27-3983-408e-abda-4c61c9a3840a").ToList();

            for (int i = 0; i < awbEntries.Count; i++)
            {
                OrdersViewModel order = new OrdersViewModel();
                order.PINO = awbEntries[i].PINo;
                order.PIDate = piEntries[i].CreatedDate.ToShortDateString();
                order.Model = piEntries[i].ItemDesc;
                order.QTY = piEntries?[i]?.ItemQty !=null ?  Convert.ToDouble(piEntries[i].ItemQty).ToString() : "0";
                order.BpCode = piEntries[i].BpCode;
                order.UserId = "ef351a27-3983-408e-abda-4c61c9a3840a";
                orders.Add(order);
            }

            return View(orders);

        }

        public IActionResult OrderDetails(string bpCode, string userId)
        {
            var awbEntries = _context.AwbEntries.Where(x => x.CreatedBy == userId && x.BpCode == bpCode).FirstOrDefault();
            var piEntries = _context.PIEntries.Where(x => x.CreatedBy == userId && x.BpCode == bpCode).FirstOrDefault();
            var delivery = _context.Deliveries.Where(x => x.CreatedBy == userId && x.BpCode == bpCode).FirstOrDefault();
            var payment = _context.Payments.Where(x => x.CreatedBy == userId && x.BpCode == bpCode).FirstOrDefault();

            OrdersViewModel order = new OrdersViewModel();
            order.PINO = awbEntries.PINo;
            order.PIDate = piEntries?.CreatedDate != null ? piEntries?.CreatedDate.ToString("dd-MM-yyyy") : DateTime.MinValue.ToString();
            order.Model = piEntries.ItemBrand;
            order.QTY = piEntries?.ItemQty != null ? Convert.ToDouble(piEntries.ItemQty).ToString() : "0";
            order.AWB = piEntries?.CreatedDate != null ? piEntries?.CreatedDate.ToString("dd-MM-yyyy") : DateTime.MinValue.ToString();
            order.Delivery = delivery?.CreatedDate != null ? delivery.CreatedDate.ToString("dd-MM-yyyy") : DateTime.MinValue.ToString();
            order.UnitPrice = piEntries.ItemPrice != null ? Convert.ToDouble(piEntries.ItemPrice).ToString() : "0";
            order.PIValue = piEntries?.PIValue != null ? Convert.ToDouble(piEntries.PIValue).ToString() : "0";
            order.PaymentDate = payment?.PaymentDate != null ? payment.PaymentDate.ToString("dd-MM-yyyy") : DateTime.MinValue.ToString();
            order.PaymentAmount = payment.Payments?.ToString();

            order.DeliveryDCNo = delivery.ID.ToString();
            order.DeliveryDate = delivery?.CreatedDate != null ? delivery.CreatedDate.ToString("dd-MM-yyyy") : DateTime.MinValue.ToString();
            order.DeliveryModel = delivery.ItemBrand;
            order.DeliveryQty = delivery.ItemQty.ToString();
            order.DeliveryColor = delivery.ItemColor;

            order.AWBFile = awbEntries.AwbFile;
            return View(order);
        }
    }
}

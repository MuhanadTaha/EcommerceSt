using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext db;
        public OrdersController(ApplicationDbContext db)
        {
            this.db = db;
        }

 

        [Authorize]
        public async Task<IActionResult> OrderHistory()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier); // بتجيب مين اليوزر من خلال الاي دي تبعه

            List<OrderDetailsViewModel> orderDetailsVMList = new List<OrderDetailsViewModel>();

            List<OrderHeader> orderHeadersList = await db.OrderHeaders.Include(m => m.ApplicationUser).Where(m => m.UserId == claim.Value).ToListAsync();

            foreach (var orderHeader in orderHeadersList)
            {
                OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
                {
                    OrderHeader = orderHeader,
                    OrderDetails = await db.OrderDetails.Where(m => m.OrderId == orderHeader.id).ToListAsync()

                };

                orderDetailsVMList.Add(orderDetailsVM); // في كل مرّة رح يتم إضافة الهيدرر والديتيلز مع كل لفة
            }

            return View(orderDetailsVMList);

        }


        public async Task<IActionResult> GetOrderDetails(int id)
        {
            OrderDetailsViewModel orderDetailsVM = new OrderDetailsViewModel()
            {
                OrderHeader = await db.OrderHeaders.Include(m => m.ApplicationUser).FirstOrDefaultAsync(m => m.id == id),
                OrderDetails = await db.OrderDetails.Where(m => m.OrderId == id).ToListAsync()
            };

            return PartialView("_IndividualOrderDetails", orderDetailsVM);
            // عشان أعمل موديل ديالوع بخلي الريتيرن ترجع بارشيال فيو وبمررله داتا أوردار ديتالز فيو موديل
        }


    }
}

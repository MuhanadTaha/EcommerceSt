using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CartsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty] // ببعت من خلالها الداتا للفيو أو باستقبلها لما ينعمنل ساب ميت
        public OrderDetailsCartViewModel OrderDetailsCartVM { get; set; }

        public IActionResult Index()
        {
            OrderDetailsCartVM = new OrderDetailsCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()

            };
            OrderDetailsCartVM.OrderHeader.OrderTotal = 0; // قيمة ابتدائية
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);// اي دي اليوزر صار موجود

            var shoppingCarts = db.ShoppingCarts.Where(c => c.ApplicationUserId == claim.Value); // بدي أرجع كل الشوبينج كارت التابعات لليوزر

            if (shoppingCarts != null) //في حال كان في اي شراء لليوزر رح أعبيها بالموديل
            {
                OrderDetailsCartVM.ShoppingCartList = shoppingCarts.ToList();
            }

            foreach (var item in OrderDetailsCartVM.ShoppingCartList) // بدي أجيب كل الايتمز اللي بالشوبينج ليست
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId); // بدي أجيب تفاصيل الاي دي ايتم 

                OrderDetailsCartVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count; // بدي أحسب ألأوردار توتل
                OrderDetailsCartVM.OrderHeader.OrderTotal = Math.Round(OrderDetailsCartVM.OrderHeader.OrderTotal, 2);// رح أقرب القيمة لأقرب منزلتين




                item.MenuItem.Description = SD.ConvertToRawHtml(item.MenuItem.Description); // عشان أشيل التاج اتش تي أم أل

                if (item.MenuItem.Description.Length > 75) // عشان أعرض 75 حرف بس
                {
                    item.MenuItem.Description = item.MenuItem.Description.Substring(0, 75);
                }
            }


            OrderDetailsCartVM.OrderHeader.OrderTotalOrginal = OrderDetailsCartVM.OrderHeader.OrderTotal; // لهان مش رح يكون في كوبون في حال كان موجود كوبون بعمل خصم


            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)  //السيشين رح تكن قيمته فيمة الكوبون
            {
                OrderDetailsCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode); // السيشين اللي أجا من أبلاي كود بعطي قيمته للبروبيرتي كوبون كود
                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() == OrderDetailsCartVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault(); //بجيب كل معلومات الكوبون الموجود كوده بالاوردار هيدار

                OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountPrice(couponFromDB, OrderDetailsCartVM.OrderHeader.OrderTotalOrginal); // بروح بنفذ الميثود الموجود بكلا اس دي وبمررها براميتار للكوبون اللي تم وضعه وبراميتار للمجموع الكلي للطلبات بعدها بطلع القيمة النهائية بعد خصم الكوبون

            }

            return View(OrderDetailsCartVM);
        }



        public IActionResult Summary()
        {
            OrderDetailsCartVM = new OrderDetailsCartViewModel()
            {
                OrderHeader = new Models.OrderHeader()

            };
            OrderDetailsCartVM.OrderHeader.OrderTotal = 0; // قيمة ابتدائية
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);// اي دي اليوزر صار موجود


            var appUser = db.ApplicationUsers.Find(claim.Value); // بجيب تفاصيل اليوزر اللي عامل لوج اين
            OrderDetailsCartVM.OrderHeader.PickUpName = appUser.Name;
            OrderDetailsCartVM.OrderHeader.PhoneNumber = appUser.PhoneNumber;
            OrderDetailsCartVM.OrderHeader.PickUpTime = DateTime.Now;








            var shoppingCarts = db.ShoppingCarts.Where(c => c.ApplicationUserId == claim.Value); // بدي أرجع كل الشوبينج كارت التابعات لليوزر

            if (shoppingCarts != null) //في حال كان في اي شراء لليوزر رح أعبيها بالموديل
            {
                OrderDetailsCartVM.ShoppingCartList = shoppingCarts.ToList();
            }

            foreach (var item in OrderDetailsCartVM.ShoppingCartList) // بدي أجيب كل الايتمز اللي بالشوبينج ليست
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId); // بدي أجيب تفاصيل الاي دي ايتم 

                OrderDetailsCartVM.OrderHeader.OrderTotal += item.MenuItem.Price * item.Count; // بدي أحسب ألأوردار توتل
                OrderDetailsCartVM.OrderHeader.OrderTotal = Math.Round(OrderDetailsCartVM.OrderHeader.OrderTotal, 2);// رح أقرب القيمة لأقرب منزلتين


            }


            OrderDetailsCartVM.OrderHeader.OrderTotalOrginal = OrderDetailsCartVM.OrderHeader.OrderTotal; // لهان مش رح يكون في كوبون في حال كان موجود كوبون بعمل خصم


            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)  //السيشين رح تكن قيمته فيمة الكوبون
            {
                OrderDetailsCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode); // السيشين اللي أجا من أبلاي كود بعطي قيمته للبروبيرتي كوبون كود
                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() == OrderDetailsCartVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault(); //بجيب كل معلومات الكوبون الموجود كوده بالاوردار هيدار

                OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountPrice(couponFromDB, OrderDetailsCartVM.OrderHeader.OrderTotalOrginal); // بروح بنفذ الميثود الموجود بكلا اس دي وبمررها براميتار للكوبون اللي تم وضعه وبراميتار للمجموع الكلي للطلبات بعدها بطلع القيمة النهائية بعد خصم الكوبون

            }

            return View(OrderDetailsCartVM);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost()
        {
           
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);// اي دي اليوزر صار موجود



            OrderDetailsCartVM.ShoppingCartList = await db.ShoppingCarts.Where(c => c.ApplicationUserId == claim.Value).ToListAsync(); // بدي أرجع كل الشوبينج كارت التابعات لليوزر


            OrderDetailsCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            OrderDetailsCartVM.OrderHeader.OrderDate = DateTime.Now;
            OrderDetailsCartVM.OrderHeader.UserId = claim.Value;
            OrderDetailsCartVM.OrderHeader.Status = SD.PaymentStatusPending;//قيمة ابتدائية انها بيندينج
            OrderDetailsCartVM.OrderHeader.PickUpTime = Convert.ToDateTime(OrderDetailsCartVM.OrderHeader.PickUpDate.ToShortDateString() + " " +
                OrderDetailsCartVM.OrderHeader.PickUpTime.ToShortTimeString());// دمجت التاريح مع الوقت عشان نخزنهن بتاريخ واحد في عمود البيك أب تايم
            OrderDetailsCartVM.OrderHeader.OrderTotalOrginal = 0; // INITIAL VALUE

            db.OrderHeaders.Add(OrderDetailsCartVM.OrderHeader); // بعد ما عملت سيت للقيم الخاصة بالأوردار هيدر ضفته بالدتا بيس
            await db.SaveChangesAsync();




            foreach (var item in OrderDetailsCartVM.ShoppingCartList) // بدي أجيب كل الايتمز اللي بالشوبينج ليست
            {
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId); // بدي أجيب تفاصيل الاي دي ايتم 

                OrderDetail orderDetail = new OrderDetail()
                {// بجيب كل القيم الخاصة بالديتيلز
                    MenuItemId = item.MenuItemId,
                    OrderId = OrderDetailsCartVM.OrderHeader.id,
                    Description=item.MenuItem.Description,
                    Name= item.MenuItem.Name,
                    Price= item.MenuItem.Price,
                    Count=item.Count
                };

                OrderDetailsCartVM.OrderHeader.OrderTotalOrginal += item.MenuItem.Price * item.Count; // بدي أحسب ألأوردار توتل
                db.OrderDetails.Add(orderDetail);
            }




            if (HttpContext.Session.GetString(SD.ssCouponCode) != null)  //السيشين رح تكن قيمته فيمة الكوبون
            {
                OrderDetailsCartVM.OrderHeader.CouponCode = HttpContext.Session.GetString(SD.ssCouponCode); // السيشين اللي أجا من أبلاي كود بعطي قيمته للبروبيرتي كوبون كود
               
                var couponFromDB = db.Coupons.Where(m => m.Name.ToLower() == OrderDetailsCartVM.OrderHeader.CouponCode.ToLower()).FirstOrDefault(); //بجيب كل معلومات الكوبون الموجود كوده بالاوردار هيدار

                OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountPrice(couponFromDB, OrderDetailsCartVM.OrderHeader.OrderTotalOrginal); // بروح بنفذ الميثود الموجود بكلا اس دي وبمررها براميتار للكوبون اللي تم وضعه وبراميتار للمجموع الكلي للطلبات بعدها بطلع القيمة النهائية بعد خصم الكوبون

            }
            else // معناها فش كويون
            {
                OrderDetailsCartVM.OrderHeader.OrderTotal =Math.Round(OrderDetailsCartVM.OrderHeader.OrderTotalOrginal,2);
            }


            OrderDetailsCartVM.OrderHeader.CouponCodeDiscount = OrderDetailsCartVM.OrderHeader.OrderTotalOrginal - OrderDetailsCartVM.OrderHeader.OrderTotal;
            db.ShoppingCarts.RemoveRange(OrderDetailsCartVM.ShoppingCartList); // بعد ما عبيت الهيدر والديتيلز بالداتا بيس فأنا بفرغ الشوبينج كارت
            HttpContext.Session.SetInt32(SD.ShoppingCartCount, 0);//قيمة السيشين المتعلق بعدد المشتريات تصير صفر
            await db.SaveChangesAsync();

            //return RedirectToAction("Index","Home"); //بترجع على صفحة الإينديكس الموجودة بالكونترولار هوم

            foreach (var item in OrderDetailsCartVM.ShoppingCartList) // بدي أجيب كل الايتمز اللي بالشوبينج ليست
            {
                // هان بدي أمر على كل الايتيمز اللي بالسلة واشوف كم الكمية اللي اله وانقصها من الداتا بيس
                item.MenuItem = db.MenuItems.FirstOrDefault(m => m.Id == item.MenuItemId); // بدي أجيب تفاصيل الاي دي ايتم 
                item.MenuItem.Count -=  item.Count; // بدي أحسب ألأوردار توتل


                db.MenuItems.Update(item.MenuItem);
                await db.SaveChangesAsync();


            }



            return RedirectToAction("OrderHistory", "Orders");
        }

        public IActionResult ApplyCoupon()
        {
            if (OrderDetailsCartVM.OrderHeader.CouponCode == null)
            {
                OrderDetailsCartVM.OrderHeader.CouponCode = "";
            }

            HttpContext.Session.SetString(SD.ssCouponCode, OrderDetailsCartVM.OrderHeader.CouponCode); // قيمة السيشين رح تكون القيمة اللي بدخلها بالتيكست بوكس، حطيتها بالسيشين عشان استخدمها بالاينديكس ميثود
            return RedirectToAction(nameof(Index));
        }


        public IActionResult RemoveCoupon()
        {

            HttpContext.Session.SetString(SD.ssCouponCode, string.Empty); // في حالة الريموف بنعطى السيشين سترينج بالتالي باليندكيس لما ترجع تحمل الصفحة رح يضل التوتال نفس ما هو من غير ما يفوت على شرط الخصم
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Plus(int cartId)
        {
            var shoppingCart = await db.ShoppingCarts.FindAsync(cartId); // بصل لواحد من اللشوبينج ايتيمز
            shoppingCart.Count += 1;

            var numberAvailable = await db.MenuItems.Where(m => m.Id == shoppingCart.MenuItemId).Select(m => m.Count).FirstOrDefaultAsync();

            if (numberAvailable >= shoppingCart.Count)
            {
                await db.SaveChangesAsync();
            }
            else
            {
                ViewBag.count = "Error : Sorry Quantity is not available";
                return Ok(ViewBag.count);
            }

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Minus(int cartId)
        {
            var shoppingCart = await db.ShoppingCarts.FindAsync(cartId); // بصل لواحد من اللشوبينج ايتيمز
          if(shoppingCart.Count > 1)
            {
                shoppingCart.Count -= 1;
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Remove(int cartId)
        {
            var shoppingCart = await db.ShoppingCarts.FindAsync(cartId); // بصل لواحد من اللشوبينج ايتيمز
            db.ShoppingCarts.Remove(shoppingCart);
            await db.SaveChangesAsync();

            var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(SD.ShoppingCartCount, count); // القيمة الجديدة للسيشين الخاص بعدد الايتيمز بعد حذف واحد أو أكثر منهن

            

            return RedirectToAction(nameof(Index));

        }



    }

}

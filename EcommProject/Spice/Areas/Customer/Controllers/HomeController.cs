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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null) { // في حال ما كان عامل اليوزر لوج اين وفات دايريكت على الانديكس
                List<ShoppingCart> shoppingCarts = await db.ShoppingCarts.Where(m => m.ApplicationUserId == claim.Value).ToListAsync();
                HttpContext.Session.SetInt32(SD.ShoppingCartCount, shoppingCarts.Count()); 

            }

            IndexViewModel IndexVM = new IndexViewModel()
            {

                Categories = await db.Cateogries.ToListAsync(),
                MenuItems = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync()

            };
            return View(IndexVM);
        }


        [HttpGet]
        [Authorize] // لازم أعمل لوج إين عشان أدخل على الديتيلز 
        public async Task<IActionResult> Details(int itemid)
        {
            var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == itemid).FirstOrDefaultAsync();
           
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                MenuItem = menuItem,
                MenuItemId = menuItem.Id
            };


            return View(shoppingCart);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize] // لازم أعمل لوج إين عشان أدخل على الديتيلز 

        public async Task<IActionResult> Details (ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                //shoppingCart.Id = 0; // بصفر الاي دي الخاص بالموديل اللي رح أستمله واللي هو شوبينج كارت عشان أحل مشكلة إنه دايما هذا الاي دي رح يوخذ الآي دي للمنيوا أيتم لأني ممرره في الجيت ميثود

                var claimsIdentity = (ClaimsIdentity)User.Identity; // عشان أجيب الكرانت يوزر اللي عمل بوست
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value; // رح يعطي الأي دي للبروبيرتي الموجودة بالشوبينج


                var shoppingCartFromDb = await db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId && m.MenuItemId == shoppingCart.MenuItemId).FirstOrDefaultAsync();
                // بدي أشوف إذا الآيتم اللي ببعتها موجود نفسها بالداتا بيس وكما هل الشخص اللي عمل بوست هو نفسه ضايفها من قبل
                if (shoppingCartFromDb == null)
                {
                    db.ShoppingCarts.Add(shoppingCart); // اذا مش موجودة الداتا معناها فش منتج فبضيفه بالتيبل أو الموديل
                }
                else
                {
                    shoppingCartFromDb.Count += shoppingCart.Count; // اذا موجود بس بزيد اقيمة الكاونت للمنتج حسب ايش أنا اخترت الكمية 
                }
                await db.SaveChangesAsync();


                var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingCart.ApplicationUserId).ToList().Count; // بدي أجيب عدد محتويات الشوبينج كارت لليورز اللي عامل دخول
                HttpContext.Session.SetInt32(SD.ShoppingCartCount,count); // وضعت قيمة الكاونت بالسيشين اللي اسمها شوبينج كارت كاونت

                return RedirectToAction(nameof(Index));



            }
            else
            {

                var menuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == shoppingCart.MenuItemId).FirstOrDefaultAsync();

                ShoppingCart shoppingCartObj = new ShoppingCart()
                {
                    MenuItem = menuItem,
                    MenuItemId = menuItem.Id
                };
                return View(shoppingCartObj);
            }
        }

    }

}

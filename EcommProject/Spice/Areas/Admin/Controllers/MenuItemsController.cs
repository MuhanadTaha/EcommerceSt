using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)] // الصلاحيات بتكون فقط لليوزر اللي عنده صلاحيات المانيجر

    [Area("Admin")]

    public class MenuItemsController : Controller
    {

        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty] //لما اعمل سابميت هاي رح تستقبل الداتا اللي رح تيجي من الفورم
        public MenuItemViewModel MenuItemVM { get; set; } // رح أستخدمها عشان أمررها لشاشات الأب ديت والديليت والكرييت
        public MenuItemsController(ApplicationDbContext db ,IWebHostEnvironment webHostEnvironment) //IWebHostEnvironment من خلالها بصل لل ستاتيك فايل اللي بال دابليو دابليو دابليو روت
        {
            this.db = db;



            this.webHostEnvironment = webHostEnvironment; // مجرّد إينيشيالايز
            MenuItemVM = new MenuItemViewModel() // بس بعمللها إنيشيالايز، يعني بعمل سيت للموديل اللي جواها
            {
                MenuItem = new MenuItem(), // بس إينيشيال بالدبداية
                CategoriesList = db.Cateogries.ToList() // عشان بالبداية لما أفوت على الصفحة تكون الداتا معبية بالدروب داون ليست
                // ما عبيت الساب كاتيجوري ليست لأنه في عندي كاسكيد، يعني بدي أعبي قيمة الساب كاتيجوري من خلال الأجاكس  بناءً على اختياري للكاتيجوري من الدروب داون ليست
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menuItems = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return View(menuItems);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(MenuItemVM); // بمرر المنيو ايتيم في أم للكريت عشان تستقبها البروبيرتي البايند  
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost() //ما بقد اسميها كريت لإني ما رح أمرر فيها داتا بالتالي سميتها كريت بوست
        {

            // بدل ما نستقبل الداتا جوا ميثود الكرييت، إحنا استخدمنا طريقة ثانية لاستقبال الداتا واللي هي بايند بروبيرتي
            if (ModelState.IsValid)
            {
                string ImagePath = @"\images\default_food.png"; // الديفولت باث للايميج في حال ما كان في صورة محملة 
                var files = HttpContext.Request.Form.Files; //كل الفايلات اللي حملتها من التشوز فايل
                if (files.Count > 0) // في حال كان في صورة محملة
                {
                    string webRootPath = webHostEnvironment.WebRootPath; // هيك رح يجيبلي روت الدابيلو دابيلو دابيلو روت فولدار

                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName); //بعطي اسم للصورة يكون يونيك
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath,"images",ImageName),FileMode.Create);//فايل مود كرييت بتنعمل لانشاء صورة داخل هذا الباث //هيك رح أدمج الباث كامل الدابليو روت مع الايميج فولدر مع اسم الصورة
                    files[0].CopyTo(fileStream);//حعمل نسخة جديدة بالاسم اليونيك

                    ImagePath = @"\images\" + ImageName; // الباث اللي رح أخزنه بالداتا بيس
                }
                MenuItemVM.MenuItem.Image = ImagePath; //لما أعمل سابميت رح  أعطي البروبيرتي اللي اسمها ايميج قيمة اليميج باث 

                db.MenuItems.Add(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(MenuItemVM);
        }





        [HttpGet]
        public  async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var menuItem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefault(m=>m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }


            MenuItemVM.MenuItem = menuItem; // الداتا كلها رح تتخزن بالموديل منيو ايتيم
            MenuItemVM.SubCategoriesList = await db.SubCateogries.Where(m => m.CategoryId == MenuItemVM.MenuItem.CategoryId).ToListAsync();
            return View(MenuItemVM);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files; //كل الفايلات اللي حملتها
                if (files.Count > 0) // في حال كان في صورة محملة
                {
                    string webRootPath = webHostEnvironment.WebRootPath; // هيك رح يجيبلي روت الدابيلو روت فولدار

                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName); //بعطي اسم للصورة يكون يونيك
                    FileStream fileStream = new FileStream(Path.Combine(webRootPath, "images", ImageName), FileMode.Create);//فايل مود كرييت بتنعمل لانشاء صورة داخل هذا الباث //هيك رحأدمج الباث كامل الدابليو روت مع الايميج فولدر مع اسم الصورة
                    files[0].CopyTo(fileStream);//حعمل نسخة جديدة بالاسم اليونيك

                    string ImagePath = @"\images\" + ImageName; // الباث اللي رح أخزنه بالداتا بيس
                    MenuItemVM.MenuItem.Image = ImagePath; //لما أعمل سابميت رح  أعطي البروبيرتي اللي اسمها ايميج قيمة اليميج باث 

                }

                db.MenuItems.Update(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(MenuItemVM);
        }




        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menuItem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefault(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }


            MenuItemVM.MenuItem = menuItem; // الداتا كلها رح تتخزن بالموديل منيو ايتيم
            MenuItemVM.SubCategoriesList = await db.SubCateogries.Where(m => m.CategoryId == MenuItemVM.MenuItem.CategoryId).ToListAsync();
            return View(MenuItemVM);
        }





        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menuItem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).SingleOrDefault(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            MenuItemVM.MenuItem = menuItem; // الداتا كلها رح تتخزن بالموديل منيو ايتيم
            MenuItemVM.SubCategoriesList = await db.SubCateogries.Where(m => m.CategoryId == MenuItemVM.MenuItem.CategoryId).ToListAsync();
            return View(MenuItemVM);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost()
        {

            db.MenuItems.Remove(MenuItemVM.MenuItem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

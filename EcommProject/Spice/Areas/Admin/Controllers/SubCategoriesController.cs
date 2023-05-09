using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModels;
using Spice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)] // الصلاحيات بتكون فقط لليوزر اللي عنده صلاحيات المانيجر

    [Area("Admin")]

    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext db;
         
        [TempData] //Temprory Value
        public string StatusMessage { get; set; }
        public SubCategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
            var subCategories = await db.SubCateogries.Include(m => m.Category).ToListAsync(); //عشان اجيب اسم الكاتيجوري
            return View(subCategories);
        }

        [HttpGet]
        public async Task <IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = new Models.SubCategory(),
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                //include means join between to tables
                var doesExistSubCategory =await db.SubCateogries.Include(m => m.Category).Where(m => m.Category.Id == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name).ToListAsync();// بدي أشوف إذا الكاتيوجوري اللي تمرر من خلال اختياري لكاتيجوري معين إذا موجود الآي دي إللي اله في الداتا بيس وبنفس الوقت بدي أشوف إذا الساب كاتيجوري اللي بندرج تحته في إله نفس الإسم
                if (doesExistSubCategory.Count() > 0)
                {
                    StatusMessage = "Error : This is Sub Category Exsists under " + doesExistSubCategory.FirstOrDefault().Category.Name + " Category";
                }
                else
                {
                    db.SubCateogries.Add(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            // في حال كان الموديل إنفاليد بدي أرجع داتا للفيو فبرجعه من خلال موديل في أم
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel() // في حال حدوث إضافة لحساب كاتيجوري موجود بكون برد برجع الداتا للصفحة وبظهر الماسج
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = model.SubCategory,
                StatusMessage = StatusMessage
            };

            return View(modelVM);

        }
        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int id) // بدي من خلالها أرجع الساب كاتيجوري من خلال الكاتيجوري اللي رح أختاره
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            subCategories = await db.SubCateogries.Where(m => m.CategoryId == id).ToListAsync();
            return Json(new SelectList(subCategories, "Id", "Name")); // السيليكت ليست رح تتحول لجيسون رح أستدعيها وأستقبلها من خلال الأجاكس
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var subCategory = await db.SubCateogries.FindAsync(id);
            if(subCategory == null)
            {
                return NotFound();
            }


            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = subCategory,
            };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                //include means join between to tables
                var doesExistSubCategory = await db.SubCateogries.Include(m => m.Category).Where(m => m.Category.Id == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name &&  m.Id != model.SubCategory.Id).ToListAsync();
                if (doesExistSubCategory.Count() > 0)
                {
                    StatusMessage = "Error : This is Sub Category Exsists under " + doesExistSubCategory.FirstOrDefault().Category.Name + " Category";
                }
                else
                {
                    db.SubCateogries.Update(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoriesList = await db.Cateogries.ToListAsync(),
                SubCategory = model.SubCategory,
                StatusMessage = StatusMessage
            };

            return View(modelVM);

        }


        [HttpGet]
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory =  db.SubCateogries.Include(m=>m.Category).Where(m => m.Id == id).SingleOrDefault();
            if (subCategory == null)
            {
                return NotFound();
            }


            return View(subCategory);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SubCategory subCategory)
        {
            db.SubCateogries.Remove(subCategory);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subCategory = db.SubCateogries.Include(m => m.Category).Where(m => m.Id == id).SingleOrDefault();
            if (subCategory == null)
            {
                return NotFound();
            }


            return View(subCategory);

        }

    }


}

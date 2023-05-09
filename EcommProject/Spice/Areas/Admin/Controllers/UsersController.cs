using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles =SD.ManagerUser)] // الصلاحيات بتكون فقط لليوزر اللي عنده صلاحيات المانيجر
    [Area("Admin")]

    public class UsersController : Controller
    {

        private readonly ApplicationDbContext db;
        public UsersController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {

            //بتم استخدامه لجلب الآي دي من اليوزر claims identity
            //هو عبارة عن بوبيرتي موجودة عشان يعرف اللي عمل تسجيل دخول user  
            var claimsIdentity = (ClaimsIdentity)User.Identity; // رح يجيب ال اي دي لليوزر اللي عامل لوج اين
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier); //بجيب أول يوزر بتطابق حسب الاي دي
            String UserId = claim.Value;
            return View( await db.ApplicationUsers.Where(m=>m.Id != UserId).ToListAsync());
        }



        public async Task<IActionResult> LockUnLock(string? id)
        {
            
            var user = await db.ApplicationUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            db.Remove(user);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class ShoppingCart
    {
        public ShoppingCart() // بعمل الكونستكراكتار عشان أعطي الكاونت اينيشيال فاليو 
        {
            Count = 1;
        }
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; } // اليوزر اي دي اللي رح يعمل بوست

        [NotMapped] // عشان ما يرتبط مع جدول اي اس بي يوزر السبب برحع لأنه ممكن اليوزر نفسه ينحذف فلما ينحذف ما ينحذف معاه المنتج إللي طلبه
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int MenuItemId { get; set; } // رقم الأيتم اللي رح يتم إضافته نعمله نت ماب لنفس سبب الأبليكيشن يوزر
        [NotMapped]
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Enter value grater than or equal 1")]
        public int Count { get; set; }


        // حذف الريليشن بوضع نات ماب عشان إذا الآيتم انحذف من الويبسايت ما ينحذف من قائمة المشتريات الفديمة وكذلك مع اليور آي دي 
    }
}

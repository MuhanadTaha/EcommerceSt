using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class OrderHeader
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string UserId { get; set; } // الشخص اللي اله هذا اليوزر

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public double OrderTotalOrginal { get; set; } // مجموع السعر الأصلي

        [Required]
        public double OrderTotal { get; set; } //مجموع السعر بعد الديسكاونت واستخدام الكوبون

        [Required]
        [Display(Name = "Pick Time")]
        public DateTime PickUpTime { get; set; } // الوقت والتاريخ اللي رح يتخزّنن بالداتا بيس

        [NotMapped] // ما رح تنضاف بقاعدة البيانات أنا مضطرلها لأني بدي أستخدم التاريخ بس
        [Required]
        public DateTime PickUpDate { get; set; } // التاريخ اللي رح أخذه من الاوردار
        [Display(Name = "Coupon Code")]
        public string CouponCode { get; set; }
        public double CouponCodeDiscount { get; set; }
        public string Status { get; set; } // حالة الطلب
        public string PaymentStatus { get; set; } // حالة الدفع
        public string Comments { get; set; }

        [Display(Name = "Pick Name")]
        public string PickUpName { get; set; } // الشخص اللي رح يستلم الطلب،.. ممكن يكون بختلف عن اللي طلب الطلب

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }//رقم الشخص اللي رح يستلم الطلب
        public string TransactionId { get; set; } // عملية الدفع



    }
}

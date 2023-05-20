using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Utility
{
    public static class SD
    {
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "Front Desk";
        public const string CusotmerEndUser = "Cusotmer";

        public const string ShoppingCartCount = "ShoppingCartCount"; // للسيشين
        public const string ssCouponCode = "CouponCode"; // للسيشين


        public const string StatusSubmitted = "Submitted";
        public const string StatusInProccess = "Begin Prepared";
        public const string StatusReady = "Ready for Picker";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";


        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";


        public static string ConvertToRawHtml(string source) //static function
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }


        public static double DiscountPrice(Coupon coupon, double OrderTotalOrginal) // بمرر تفاصيل الكوبون اللي جاييني وبمرر القيمة الأصلية لمجموع المشتريات
        {
            if (coupon == null) // نال معناها الكود اللي محطوط بالتيكست بوكس مش موجود ضمن الكودات في تيبيل الكوبون 
            {
                return Math.Round(OrderTotalOrginal, 2); // بهذي الحالة رح يرجع القيمة الأصلية لمجموع المشتريات
            }
            else
            {
                if (coupon.MinimumAmmount > OrderTotalOrginal) // في حال كان عندي المينيموم أماونت اكبر من التوتال فما رح يكون فعّال هذا الكوبون
                {
                    return Math.Round(OrderTotalOrginal, 2); // اذا ما في خصم فبرجع القيمة الأصلية ببمشتريات
                }
                else
                {// الكود فعّال
                    if (int.Parse(coupon.CouponType) == (int)Coupon.ECouponType.Shekel) // اذا كان الكوبون بالدولار
                    {
                        return Math.Round(OrderTotalOrginal - coupon.Discount, 2); //بطرح السعر الأورجينال من الخصم تبع الكوبون وبقربه لأقرب منزلتين
                    }
                    else
                    {
                        return Math.Round(OrderTotalOrginal - (OrderTotalOrginal * (coupon.Discount / 100)), 2); // اذا كان نسبة مئوية
                    }
                }

            }
        }
    }
}

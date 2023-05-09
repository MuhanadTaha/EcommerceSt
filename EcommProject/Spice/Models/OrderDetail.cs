using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class OrderDetail
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        public int Count { get; set; } // بجيب الكاونت والنيم الجيكسريبشن والبرايس عشان في حال تعدل على أي ايتيم بالمنيو ايتم ما يأثر علي ايش كان العنصر لما تم شراؤه وايش سعره ووصفه
        public string  Name { get; set; }
        public string Description { get; set; }
        public double  Price { get; set; }
    }
}
